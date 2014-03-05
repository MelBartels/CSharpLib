using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using GenLib.Extensions;

namespace AstroLib.Extensions
{
    public static class VisualExtensions
    {
        public static void ShowCellContents<T>(this T t, DataGridViewCellEventArgs e, Action<string> action)
            where T : DataGridView
        {
            (e.RowIndex >= 0).Then(() => action(t[e.ColumnIndex, e.RowIndex].Value as string));
        }

        public static void GetFocusedColRowChanged<T>(this T t, Action<T> onNextAction)
            where T : GridView
        {
            var colChanged = t.GetFocusedColumnChanged().Select(e => e.Sender.CastSafe<T>());
            var rowChanged = t.GetFocusedRowChanged().Select(e => e.Sender.CastSafe<T>());

            colChanged
                .Merge(rowChanged)
                .Skip(2)
                .BufferWithTimeOrCount(new TimeSpan(0, 0, 0, 0, 100), 2)
                .SelectMany(obsOfT => obsOfT.TakeLast(1))
                .Subscribe(onNextAction);
        }

        public static void SetToolTip<T>(this T t,
                                         IEvent<ToolTipControllerGetActiveObjectInfoEventArgs> infoEventArgs,
                                         Func<GridHitInfo, string> calcDisplayValue)
            where T : GridView
        {
            t.CalcHitInfo(infoEventArgs.EventArgs.ControlMousePosition)
                .If(gridHitInfo => gridHitInfo.HitTest == GridHitTest.RowCell)
                .Do(gridHitInfo =>
                    new ToolTipControlInfo(new CellToolTipInfo(gridHitInfo.RowHandle, gridHitInfo.Column, "cell"),
                                           calcDisplayValue(gridHitInfo))
                        .Do(toolTipControlInfo => infoEventArgs.EventArgs.Info = toolTipControlInfo));
        }
    }
}