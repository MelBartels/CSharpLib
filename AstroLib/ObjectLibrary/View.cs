using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AstroLib.Extensions;
using AstroLib.ObjectLibrary.Description;
using AstroLib.ObjectLibrary.SAC;
using AstroLib.Properties;
using AstroLib.VisualDetection;
using AstroLib.VisualDetection.Calculator;
using AstroLib.VisualDetection.CanCalculate;
using AutoMapper;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using GenLib.Extensions;
using GenLib.Messaging;
using GenLib.Startup;
using GenLib.View;
using Record = AstroLib.ObjectLibrary.SAC.Record;

namespace AstroLib.ObjectLibrary
{
    public partial class View : ViewBase
    {
        private const string MinimumApertureTip = "The minimum aperture (inches) necessary to detect the object with sky background brightness of ";
        private const string BestExitPupilTip = "The best exit pupil (mm) to use";

        public View() : this(new ViewModel(),
                             new AboutScreen(),
                             new SAC.Loader<Record>(),
                             new Catalogs(),
                             new ObjectType(),
                             new Classification(),
                             new Lookup(),
                             new IsVisibleHelper(),
                             new MinApertureBestExitPupil())
        {
        }

        public View(ViewModel viewModel,
                    AboutScreen aboutScreen,
                    SAC.Loader<Record> loader,
                    Catalogs catalogs,
                    ObjectType objectType,
                    Classification classification,
                    Lookup lookup,
                    IsVisibleHelper isVisibleHelper,
                    MinApertureBestExitPupil minApertureBestExitPupil)
        {
            InitializeComponent();

            ViewModel = viewModel;
            AboutScreen = aboutScreen;
            Loader = loader;
            Catalogs = catalogs;
            ObjectType = objectType;
            Classification = classification;
            Lookup = lookup;
            IsVisibleHelper = isVisibleHelper;
            MinApertureBestExitPupil = minApertureBestExitPupil;

            SkyBkgndBrightness = 21.5;

            Subscribe();
        }

        private ViewModel ViewModel { get; set; }
        private AboutScreen AboutScreen { get; set; }
        private SAC.Loader<Record> Loader { get; set; }
        private Catalogs Catalogs { get; set; }
        private ObjectType ObjectType { get; set; }
        private Classification Classification { get; set; }
        private Lookup Lookup { get; set; }
        private IsVisibleHelper IsVisibleHelper { get; set; }
        private MinApertureBestExitPupil MinApertureBestExitPupil { get; set; }
        private DisplayRecord LastDisplayRecord { get; set; }
        private double SkyBkgndBrightness { get; set; }
        private double CalcAperturesSkyBkgndBrightness { get; set; }

        public MessageToken ObjectSelectedToken { get; set; }

        public override sealed void Subscribe()
        {
            ViewModel.Subscribe();

            this.GetVisibleChanged().Where(_ => Visible).Subscribe(_ => GridControlObjects.DataSource = LoadData());

            GridViewObjects.GetFocusedRowChanged().Where(_ => GridViewObjects.IsVisible).Subscribe(SendSelectedRecord);

            aboutToolStripMenuItem.GetClick().Subscribe(_ => AboutScreen.ShowDialog());
            exitToolStripMenuItem.GetClick().Subscribe(_ => Close());
            calcApertureToolStripMenuItem.GetClick().Subscribe(_ => CalcApertures());

            ToolTipController.GetGetActiveObjectInfo().Subscribe(ToolTipControllerGetActiveObjectInfo);

            Messenger.Instance().OfType<SkyBkgndBrightnessMessage>()
                .Subscribe(m => SkyBkgndBrightness = m.Brightness);
        }

        private List<DisplayRecord> LoadData()
        {
            return Loader
                .Load(Settings.Default.SaguaroLibraryFilename)
                .Select(Mapper.Map<Record, DisplayRecord>)
                .ToList();
        }

        private void SendSelectedRecord(IEvent<FocusedRowChangedEventArgs> e)
        {
            ((GridView) e.Sender)
                .Do(gv => gv.GetRow(gv.GetSelectedRows()[0])
                              .CastSafe<DisplayRecord>()
                              .If(r => r != LastDisplayRecord)
                              .Do(r => Messenger.Instance().Send(new RecordMessage {DisplayRecord = r}))
                              .Do(r => LastDisplayRecord = r));
        }

        private void CalcApertures()
        {
            CalcAperturesSkyBkgndBrightness = SkyBkgndBrightness;
            var view = new GenLib.Progress.Manual.View();
            new Thread(() => view.ShowDialog()) {Name = "CalcApertures"}.Start();
            view.SetParms("Calculate Progress", "Calculating minimum apertures and best exit pupils to detect objects");
            var progState = new ProgressState
                                {
                                    Total = GridViewObjects.DataSource.CastSafe<List<DisplayRecord>>().Count,
                                    Current = 0,
                                    Interval = 100,
                                };

            GridViewObjects.DataSource.CastSafe<List<DisplayRecord>>()
                .ForEach(displayRecord =>
                             {
                                 CalcAnAperture(displayRecord);
                                 progState.IncrementAndReport(view.UpdateProgress);
                             });
            view.InvokeExt(v => v.Close());
            GridViewObjects.RefreshData();
        }

        private void CalcAnAperture(DisplayRecord displayRecord)
        {
            IsVisibleHelper.Calc(displayRecord)
                .Then(() =>
                          {
                              MinApertureBestExitPupil.BkgndBrightEye = SkyBkgndBrightness;
                              MinApertureBestExitPupil.ApparentFoV = 100;

                              MinApertureBestExitPupil.ObjMag = IsVisibleHelper.ObjectMagnitude;
                              MinApertureBestExitPupil.MaxObjArcmin = IsVisibleHelper.ObjectSize1;
                              MinApertureBestExitPupil.MinObjArcmin = IsVisibleHelper.ObjectSize2;

                              MinApertureBestExitPupil.Calc();
                              (MinApertureBestExitPupil.MinimumApertureIn > 0)
                                  .Then(() => SetVisibleApertureDisplay(displayRecord));
                          });
        }

        private void SetVisibleApertureDisplay(DisplayRecord displayRecord)
        {
            displayRecord.MinimumAperture = MinApertureBestExitPupil.MinimumApertureIn;
            displayRecord.BestExitPupil = MinApertureBestExitPupil.BestExitPupilmm;
        }

        private void ToolTipControllerGetActiveObjectInfo(IEvent<ToolTipControllerGetActiveObjectInfoEventArgs> e)
        {
            GridViewObjects.SetToolTip(e, CalcDisplayValue);
        }

        private string CalcDisplayValue(GridHitInfo gridHitInfo)
        {
            return GridViewObjects.GetRowCellValue(gridHitInfo.RowHandle, gridHitInfo.Column)
                .Return(rcv =>
                            {
                                var value = rcv.ToString();
                                var catValue = value;
                                var typeValue = value;
                                var descriptionValue = value;
                                var classValue = value;

                                (gridHitInfo.Column.FieldName == "Name" || gridHitInfo.Column.FieldName == "OtherName")
                                    .Then(() => value = Catalogs.GetFrom(catValue));

                                (gridHitInfo.Column.FieldName == "Type")
                                    .Then(() => value = ObjectType.GetFrom(typeValue));

                                (gridHitInfo.Column.FieldName == "Description")
                                    .Then(() => value = Lookup.GetFrom(descriptionValue));

                                (gridHitInfo.Column.FieldName == "Classification")
                                    .Then(() => value = Classification.GetFrom(
                                        GridViewObjects.GetRowCellValue(gridHitInfo.RowHandle, "Type").ToString(),
                                        classValue));

                                (gridHitInfo.Column.FieldName == "MinimumAperture")
                                    .Then(() => value = MinimumApertureTip + CalcAperturesSkyBkgndBrightness + " mag/arcsec^2");

                                (gridHitInfo.Column.FieldName == "BestExitPupil")
                                    .Then(() => value = BestExitPupilTip);

                                return value;
                            }, string.Empty);
        }

        #region Nested type: ProgressState

        private class ProgressState
        {
            public int Total { get; set; }
            public int Current { get; set; }
            public int Interval { get; set; }

            public void IncrementAndReport(Action<string, int> action)
            {
                (Current++ % Interval == 0)
                    .Then(() => action("updated " + Current + " of " + Total + " objects", 100 * Current / Total));
            }
        }

        #endregion
    }
}