using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Printing;

namespace AstroLib.Extensions
{
	public static class GridControlExtensions 
	{
	                    
        public static IObservable<IEvent<EventArgs>> GetDataSourceChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.DataSourceChanged += h, 
                    h => el.DataSourceChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDefaultViewChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.DefaultViewChanged += h, 
                    h => el.DefaultViewChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetLoad (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Load += h, 
                    h => el.Load -= h
                );
        }
                        
        public static IObservable<IEvent<ViewOperationEventArgs>> GetViewRegistered (this GridControl el)
        {
            return Observable.FromEvent<ViewOperationEventHandler, ViewOperationEventArgs>
                (   
                    h => new ViewOperationEventHandler(h), 
                    h => el.ViewRegistered += h, 
                    h => el.ViewRegistered -= h
                );
        }
                        
        public static IObservable<IEvent<ViewOperationEventArgs>> GetViewRemoved (this GridControl el)
        {
            return Observable.FromEvent<ViewOperationEventHandler, ViewOperationEventArgs>
                (   
                    h => new ViewOperationEventHandler(h), 
                    h => el.ViewRemoved += h, 
                    h => el.ViewRemoved -= h
                );
        }
                        
        public static IObservable<IEvent<KeyEventArgs>> GetProcessGridKey (this GridControl el)
        {
            return Observable.FromEvent<KeyEventHandler, KeyEventArgs>
                (   
                    h => new KeyEventHandler(h), 
                    h => el.ProcessGridKey += h, 
                    h => el.ProcessGridKey -= h
                );
        }
                        
        public static IObservable<IEvent<ViewFocusEventArgs>> GetKeyboardFocusViewChanged (this GridControl el)
        {
            return Observable.FromEvent<ViewFocusEventHandler, ViewFocusEventArgs>
                (   
                    h => new ViewFocusEventHandler(h), 
                    h => el.KeyboardFocusViewChanged += h, 
                    h => el.KeyboardFocusViewChanged -= h
                );
        }
                        
        public static IObservable<IEvent<ViewFocusEventArgs>> GetFocusedViewChanged (this GridControl el)
        {
            return Observable.FromEvent<ViewFocusEventHandler, ViewFocusEventArgs>
                (   
                    h => new ViewFocusEventHandler(h), 
                    h => el.FocusedViewChanged += h, 
                    h => el.FocusedViewChanged -= h
                );
        }
                        
        public static IObservable<IEvent<KeyEventArgs>> GetEditorKeyDown (this GridControl el)
        {
            return Observable.FromEvent<KeyEventHandler, KeyEventArgs>
                (   
                    h => new KeyEventHandler(h), 
                    h => el.EditorKeyDown += h, 
                    h => el.EditorKeyDown -= h
                );
        }
                        
        public static IObservable<IEvent<KeyEventArgs>> GetEditorKeyUp (this GridControl el)
        {
            return Observable.FromEvent<KeyEventHandler, KeyEventArgs>
                (   
                    h => new KeyEventHandler(h), 
                    h => el.EditorKeyUp += h, 
                    h => el.EditorKeyUp -= h
                );
        }
                        
        public static IObservable<IEvent<KeyPressEventArgs>> GetEditorKeyPress (this GridControl el)
        {
            return Observable.FromEvent<KeyPressEventHandler, KeyPressEventArgs>
                (   
                    h => new KeyPressEventHandler(h), 
                    h => el.EditorKeyPress += h, 
                    h => el.EditorKeyPress -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetAutoSizeChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.AutoSizeChanged += h, 
                    h => el.AutoSizeChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetBackColorChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.BackColorChanged += h, 
                    h => el.BackColorChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetBackgroundImageChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.BackgroundImageChanged += h, 
                    h => el.BackgroundImageChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetBackgroundImageLayoutChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.BackgroundImageLayoutChanged += h, 
                    h => el.BackgroundImageLayoutChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetBindingContextChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.BindingContextChanged += h, 
                    h => el.BindingContextChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetCausesValidationChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.CausesValidationChanged += h, 
                    h => el.CausesValidationChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetClientSizeChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ClientSizeChanged += h, 
                    h => el.ClientSizeChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetContextMenuChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ContextMenuChanged += h, 
                    h => el.ContextMenuChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetContextMenuStripChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ContextMenuStripChanged += h, 
                    h => el.ContextMenuStripChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetCursorChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.CursorChanged += h, 
                    h => el.CursorChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDockChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.DockChanged += h, 
                    h => el.DockChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetEnabledChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.EnabledChanged += h, 
                    h => el.EnabledChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetFontChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.FontChanged += h, 
                    h => el.FontChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetForeColorChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ForeColorChanged += h, 
                    h => el.ForeColorChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetLocationChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.LocationChanged += h, 
                    h => el.LocationChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetMarginChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.MarginChanged += h, 
                    h => el.MarginChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetRegionChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.RegionChanged += h, 
                    h => el.RegionChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetRightToLeftChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.RightToLeftChanged += h, 
                    h => el.RightToLeftChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetSizeChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.SizeChanged += h, 
                    h => el.SizeChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetTabIndexChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.TabIndexChanged += h, 
                    h => el.TabIndexChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetTabStopChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.TabStopChanged += h, 
                    h => el.TabStopChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetTextChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.TextChanged += h, 
                    h => el.TextChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetVisibleChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.VisibleChanged += h, 
                    h => el.VisibleChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetClick (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Click += h, 
                    h => el.Click -= h
                );
        }
                        
        public static IObservable<IEvent<ControlEventArgs>> GetControlAdded (this GridControl el)
        {
            return Observable.FromEvent<ControlEventHandler, ControlEventArgs>
                (   
                    h => new ControlEventHandler(h), 
                    h => el.ControlAdded += h, 
                    h => el.ControlAdded -= h
                );
        }
                        
        public static IObservable<IEvent<ControlEventArgs>> GetControlRemoved (this GridControl el)
        {
            return Observable.FromEvent<ControlEventHandler, ControlEventArgs>
                (   
                    h => new ControlEventHandler(h), 
                    h => el.ControlRemoved += h, 
                    h => el.ControlRemoved -= h
                );
        }
                        
        public static IObservable<IEvent<DragEventArgs>> GetDragDrop (this GridControl el)
        {
            return Observable.FromEvent<DragEventHandler, DragEventArgs>
                (   
                    h => new DragEventHandler(h), 
                    h => el.DragDrop += h, 
                    h => el.DragDrop -= h
                );
        }
                        
        public static IObservable<IEvent<DragEventArgs>> GetDragEnter (this GridControl el)
        {
            return Observable.FromEvent<DragEventHandler, DragEventArgs>
                (   
                    h => new DragEventHandler(h), 
                    h => el.DragEnter += h, 
                    h => el.DragEnter -= h
                );
        }
                        
        public static IObservable<IEvent<DragEventArgs>> GetDragOver (this GridControl el)
        {
            return Observable.FromEvent<DragEventHandler, DragEventArgs>
                (   
                    h => new DragEventHandler(h), 
                    h => el.DragOver += h, 
                    h => el.DragOver -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDragLeave (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.DragLeave += h, 
                    h => el.DragLeave -= h
                );
        }
                        
        public static IObservable<IEvent<GiveFeedbackEventArgs>> GetGiveFeedback (this GridControl el)
        {
            return Observable.FromEvent<GiveFeedbackEventHandler, GiveFeedbackEventArgs>
                (   
                    h => new GiveFeedbackEventHandler(h), 
                    h => el.GiveFeedback += h, 
                    h => el.GiveFeedback -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetHandleCreated (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.HandleCreated += h, 
                    h => el.HandleCreated -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetHandleDestroyed (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.HandleDestroyed += h, 
                    h => el.HandleDestroyed -= h
                );
        }
                        
        public static IObservable<IEvent<HelpEventArgs>> GetHelpRequested (this GridControl el)
        {
            return Observable.FromEvent<HelpEventHandler, HelpEventArgs>
                (   
                    h => new HelpEventHandler(h), 
                    h => el.HelpRequested += h, 
                    h => el.HelpRequested -= h
                );
        }
                        
        public static IObservable<IEvent<InvalidateEventArgs>> GetInvalidated (this GridControl el)
        {
            return Observable.FromEvent<InvalidateEventHandler, InvalidateEventArgs>
                (   
                    h => new InvalidateEventHandler(h), 
                    h => el.Invalidated += h, 
                    h => el.Invalidated -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetPaddingChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.PaddingChanged += h, 
                    h => el.PaddingChanged -= h
                );
        }
                        
        public static IObservable<IEvent<PaintEventArgs>> GetPaint (this GridControl el)
        {
            return Observable.FromEvent<PaintEventHandler, PaintEventArgs>
                (   
                    h => new PaintEventHandler(h), 
                    h => el.Paint += h, 
                    h => el.Paint -= h
                );
        }
                        
        public static IObservable<IEvent<QueryContinueDragEventArgs>> GetQueryContinueDrag (this GridControl el)
        {
            return Observable.FromEvent<QueryContinueDragEventHandler, QueryContinueDragEventArgs>
                (   
                    h => new QueryContinueDragEventHandler(h), 
                    h => el.QueryContinueDrag += h, 
                    h => el.QueryContinueDrag -= h
                );
        }
                        
        public static IObservable<IEvent<QueryAccessibilityHelpEventArgs>> GetQueryAccessibilityHelp (this GridControl el)
        {
            return Observable.FromEvent<QueryAccessibilityHelpEventHandler, QueryAccessibilityHelpEventArgs>
                (   
                    h => new QueryAccessibilityHelpEventHandler(h), 
                    h => el.QueryAccessibilityHelp += h, 
                    h => el.QueryAccessibilityHelp -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDoubleClick (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.DoubleClick += h, 
                    h => el.DoubleClick -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetEnter (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Enter += h, 
                    h => el.Enter -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetGotFocus (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.GotFocus += h, 
                    h => el.GotFocus -= h
                );
        }
                        
        public static IObservable<IEvent<KeyEventArgs>> GetKeyDown (this GridControl el)
        {
            return Observable.FromEvent<KeyEventHandler, KeyEventArgs>
                (   
                    h => new KeyEventHandler(h), 
                    h => el.KeyDown += h, 
                    h => el.KeyDown -= h
                );
        }
                        
        public static IObservable<IEvent<KeyPressEventArgs>> GetKeyPress (this GridControl el)
        {
            return Observable.FromEvent<KeyPressEventHandler, KeyPressEventArgs>
                (   
                    h => new KeyPressEventHandler(h), 
                    h => el.KeyPress += h, 
                    h => el.KeyPress -= h
                );
        }
                        
        public static IObservable<IEvent<KeyEventArgs>> GetKeyUp (this GridControl el)
        {
            return Observable.FromEvent<KeyEventHandler, KeyEventArgs>
                (   
                    h => new KeyEventHandler(h), 
                    h => el.KeyUp += h, 
                    h => el.KeyUp -= h
                );
        }
                        
        public static IObservable<IEvent<LayoutEventArgs>> GetLayout (this GridControl el)
        {
            return Observable.FromEvent<LayoutEventHandler, LayoutEventArgs>
                (   
                    h => new LayoutEventHandler(h), 
                    h => el.Layout += h, 
                    h => el.Layout -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetLeave (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Leave += h, 
                    h => el.Leave -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetLostFocus (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.LostFocus += h, 
                    h => el.LostFocus -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseClick (this GridControl el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseClick += h, 
                    h => el.MouseClick -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseDoubleClick (this GridControl el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseDoubleClick += h, 
                    h => el.MouseDoubleClick -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetMouseCaptureChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.MouseCaptureChanged += h, 
                    h => el.MouseCaptureChanged -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseDown (this GridControl el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseDown += h, 
                    h => el.MouseDown -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetMouseEnter (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.MouseEnter += h, 
                    h => el.MouseEnter -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetMouseLeave (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.MouseLeave += h, 
                    h => el.MouseLeave -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetMouseHover (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.MouseHover += h, 
                    h => el.MouseHover -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseMove (this GridControl el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseMove += h, 
                    h => el.MouseMove -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseUp (this GridControl el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseUp += h, 
                    h => el.MouseUp -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseWheel (this GridControl el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseWheel += h, 
                    h => el.MouseWheel -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetMove (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Move += h, 
                    h => el.Move -= h
                );
        }
                        
        public static IObservable<IEvent<PreviewKeyDownEventArgs>> GetPreviewKeyDown (this GridControl el)
        {
            return Observable.FromEvent<PreviewKeyDownEventHandler, PreviewKeyDownEventArgs>
                (   
                    h => new PreviewKeyDownEventHandler(h), 
                    h => el.PreviewKeyDown += h, 
                    h => el.PreviewKeyDown -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetResize (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Resize += h, 
                    h => el.Resize -= h
                );
        }
                        
        public static IObservable<IEvent<UICuesEventArgs>> GetChangeUICues (this GridControl el)
        {
            return Observable.FromEvent<UICuesEventHandler, UICuesEventArgs>
                (   
                    h => new UICuesEventHandler(h), 
                    h => el.ChangeUICues += h, 
                    h => el.ChangeUICues -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetStyleChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.StyleChanged += h, 
                    h => el.StyleChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetSystemColorsChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.SystemColorsChanged += h, 
                    h => el.SystemColorsChanged -= h
                );
        }
                        
        public static IObservable<IEvent<CancelEventArgs>> GetValidating (this GridControl el)
        {
            return Observable.FromEvent<CancelEventHandler, CancelEventArgs>
                (   
                    h => new CancelEventHandler(h), 
                    h => el.Validating += h, 
                    h => el.Validating -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetValidated (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Validated += h, 
                    h => el.Validated -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetParentChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ParentChanged += h, 
                    h => el.ParentChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetImeModeChanged (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ImeModeChanged += h, 
                    h => el.ImeModeChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDisposed (this GridControl el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Disposed += h, 
                    h => el.Disposed -= h
                );
        }
    }

public static class GridViewExtensions 
	{
		                    
        public static IObservable<IEvent<CancelPrintRowEventArgs>> GetBeforePrintRow (this GridView el)
        {
            return Observable.FromEvent<BeforePrintRowEventHandler, CancelPrintRowEventArgs>
                (   
                    h => new BeforePrintRowEventHandler(h), 
                    h => el.BeforePrintRow += h, 
                    h => el.BeforePrintRow -= h
                );
        }
                        
        public static IObservable<IEvent<PrintRowEventArgs>> GetAfterPrintRow (this GridView el)
        {
            return Observable.FromEvent<AfterPrintRowEventHandler, PrintRowEventArgs>
                (   
                    h => new AfterPrintRowEventHandler(h), 
                    h => el.AfterPrintRow += h, 
                    h => el.AfterPrintRow -= h
                );
        }
                        
        public static IObservable<IEvent<RowClickEventArgs>> GetRowClick (this GridView el)
        {
            return Observable.FromEvent<RowClickEventHandler, RowClickEventArgs>
                (   
                    h => new RowClickEventHandler(h), 
                    h => el.RowClick += h, 
                    h => el.RowClick -= h
                );
        }
                        
        public static IObservable<IEvent<RowCellClickEventArgs>> GetRowCellClick (this GridView el)
        {
            return Observable.FromEvent<RowCellClickEventHandler, RowCellClickEventArgs>
                (   
                    h => new RowCellClickEventHandler(h), 
                    h => el.RowCellClick += h, 
                    h => el.RowCellClick -= h
                );
        }
                        
        public static IObservable<IEvent<CellMergeEventArgs>> GetCellMerge (this GridView el)
        {
            return Observable.FromEvent<CellMergeEventHandler, CellMergeEventArgs>
                (   
                    h => new CellMergeEventHandler(h), 
                    h => el.CellMerge += h, 
                    h => el.CellMerge -= h
                );
        }
                        
        public static IObservable<IEvent<DragObjectDropEventArgs>> GetDragObjectDrop (this GridView el)
        {
            return Observable.FromEvent<DragObjectDropEventHandler, DragObjectDropEventArgs>
                (   
                    h => new DragObjectDropEventHandler(h), 
                    h => el.DragObjectDrop += h, 
                    h => el.DragObjectDrop -= h
                );
        }
                        
        public static IObservable<IEvent<DragObjectStartEventArgs>> GetDragObjectStart (this GridView el)
        {
            return Observable.FromEvent<DragObjectStartEventHandler, DragObjectStartEventArgs>
                (   
                    h => new DragObjectStartEventHandler(h), 
                    h => el.DragObjectStart += h, 
                    h => el.DragObjectStart -= h
                );
        }
                        
        public static IObservable<IEvent<DragObjectOverEventArgs>> GetDragObjectOver (this GridView el)
        {
            return Observable.FromEvent<DragObjectOverEventHandler, DragObjectOverEventArgs>
                (   
                    h => new DragObjectOverEventHandler(h), 
                    h => el.DragObjectOver += h, 
                    h => el.DragObjectOver -= h
                );
        }
                        
        public static IObservable<IEvent<CustomDrawEventArgs>> GetCustomDrawGroupPanel (this GridView el)
        {
            return Observable.FromEvent<CustomDrawEventHandler, CustomDrawEventArgs>
                (   
                    h => new CustomDrawEventHandler(h), 
                    h => el.CustomDrawGroupPanel += h, 
                    h => el.CustomDrawGroupPanel -= h
                );
        }
                        
        public static IObservable<IEvent<ColumnHeaderCustomDrawEventArgs>> GetCustomDrawColumnHeader (this GridView el)
        {
            return Observable.FromEvent<ColumnHeaderCustomDrawEventHandler, ColumnHeaderCustomDrawEventArgs>
                (   
                    h => new ColumnHeaderCustomDrawEventHandler(h), 
                    h => el.CustomDrawColumnHeader += h, 
                    h => el.CustomDrawColumnHeader -= h
                );
        }
                        
        public static IObservable<IEvent<RowIndicatorCustomDrawEventArgs>> GetCustomDrawRowIndicator (this GridView el)
        {
            return Observable.FromEvent<RowIndicatorCustomDrawEventHandler, RowIndicatorCustomDrawEventArgs>
                (   
                    h => new RowIndicatorCustomDrawEventHandler(h), 
                    h => el.CustomDrawRowIndicator += h, 
                    h => el.CustomDrawRowIndicator -= h
                );
        }
                        
        public static IObservable<IEvent<RowCellCustomDrawEventArgs>> GetCustomDrawCell (this GridView el)
        {
            return Observable.FromEvent<RowCellCustomDrawEventHandler, RowCellCustomDrawEventArgs>
                (   
                    h => new RowCellCustomDrawEventHandler(h), 
                    h => el.CustomDrawCell += h, 
                    h => el.CustomDrawCell -= h
                );
        }
                        
        public static IObservable<IEvent<FooterCellCustomDrawEventArgs>> GetCustomDrawRowFooterCell (this GridView el)
        {
            return Observable.FromEvent<FooterCellCustomDrawEventHandler, FooterCellCustomDrawEventArgs>
                (   
                    h => new FooterCellCustomDrawEventHandler(h), 
                    h => el.CustomDrawRowFooterCell += h, 
                    h => el.CustomDrawRowFooterCell -= h
                );
        }
                        
        public static IObservable<IEvent<FooterCellCustomDrawEventArgs>> GetCustomDrawFooterCell (this GridView el)
        {
            return Observable.FromEvent<FooterCellCustomDrawEventHandler, FooterCellCustomDrawEventArgs>
                (   
                    h => new FooterCellCustomDrawEventHandler(h), 
                    h => el.CustomDrawFooterCell += h, 
                    h => el.CustomDrawFooterCell -= h
                );
        }
                        
        public static IObservable<IEvent<RowObjectCustomDrawEventArgs>> GetCustomDrawRowPreview (this GridView el)
        {
            return Observable.FromEvent<RowObjectCustomDrawEventHandler, RowObjectCustomDrawEventArgs>
                (   
                    h => new RowObjectCustomDrawEventHandler(h), 
                    h => el.CustomDrawRowPreview += h, 
                    h => el.CustomDrawRowPreview -= h
                );
        }
                        
        public static IObservable<IEvent<RowObjectCustomDrawEventArgs>> GetCustomDrawGroupRow (this GridView el)
        {
            return Observable.FromEvent<RowObjectCustomDrawEventHandler, RowObjectCustomDrawEventArgs>
                (   
                    h => new RowObjectCustomDrawEventHandler(h), 
                    h => el.CustomDrawGroupRow += h, 
                    h => el.CustomDrawGroupRow -= h
                );
        }
                        
        public static IObservable<IEvent<RowObjectCustomDrawEventArgs>> GetCustomDrawRowFooter (this GridView el)
        {
            return Observable.FromEvent<RowObjectCustomDrawEventHandler, RowObjectCustomDrawEventArgs>
                (   
                    h => new RowObjectCustomDrawEventHandler(h), 
                    h => el.CustomDrawRowFooter += h, 
                    h => el.CustomDrawRowFooter -= h
                );
        }
                        
        public static IObservable<IEvent<RowObjectCustomDrawEventArgs>> GetCustomDrawFooter (this GridView el)
        {
            return Observable.FromEvent<RowObjectCustomDrawEventHandler, RowObjectCustomDrawEventArgs>
                (   
                    h => new RowObjectCustomDrawEventHandler(h), 
                    h => el.CustomDrawFooter += h, 
                    h => el.CustomDrawFooter -= h
                );
        }
                        
        public static IObservable<IEvent<GroupLevelStyleEventArgs>> GetGroupLevelStyle (this GridView el)
        {
            return Observable.FromEvent<GroupLevelStyleEventHandler, GroupLevelStyleEventArgs>
                (   
                    h => new GroupLevelStyleEventHandler(h), 
                    h => el.GroupLevelStyle += h, 
                    h => el.GroupLevelStyle -= h
                );
        }
                        
        public static IObservable<IEvent<RowCellStyleEventArgs>> GetRowCellStyle (this GridView el)
        {
            return Observable.FromEvent<RowCellStyleEventHandler, RowCellStyleEventArgs>
                (   
                    h => new RowCellStyleEventHandler(h), 
                    h => el.RowCellStyle += h, 
                    h => el.RowCellStyle -= h
                );
        }
                        
        public static IObservable<IEvent<RowStyleEventArgs>> GetRowStyle (this GridView el)
        {
            return Observable.FromEvent<RowStyleEventHandler, RowStyleEventArgs>
                (   
                    h => new RowStyleEventHandler(h), 
                    h => el.RowStyle += h, 
                    h => el.RowStyle -= h
                );
        }
                        
        public static IObservable<IEvent<MasterRowEmptyEventArgs>> GetMasterRowEmpty (this GridView el)
        {
            return Observable.FromEvent<MasterRowEmptyEventHandler, MasterRowEmptyEventArgs>
                (   
                    h => new MasterRowEmptyEventHandler(h), 
                    h => el.MasterRowEmpty += h, 
                    h => el.MasterRowEmpty -= h
                );
        }
                        
        public static IObservable<IEvent<MasterRowCanExpandEventArgs>> GetMasterRowExpanding (this GridView el)
        {
            return Observable.FromEvent<MasterRowCanExpandEventHandler, MasterRowCanExpandEventArgs>
                (   
                    h => new MasterRowCanExpandEventHandler(h), 
                    h => el.MasterRowExpanding += h, 
                    h => el.MasterRowExpanding -= h
                );
        }
                        
        public static IObservable<IEvent<CustomMasterRowEventArgs>> GetMasterRowExpanded (this GridView el)
        {
            return Observable.FromEvent<CustomMasterRowEventHandler, CustomMasterRowEventArgs>
                (   
                    h => new CustomMasterRowEventHandler(h), 
                    h => el.MasterRowExpanded += h, 
                    h => el.MasterRowExpanded -= h
                );
        }
                        
        public static IObservable<IEvent<MasterRowCanExpandEventArgs>> GetMasterRowCollapsing (this GridView el)
        {
            return Observable.FromEvent<MasterRowCanExpandEventHandler, MasterRowCanExpandEventArgs>
                (   
                    h => new MasterRowCanExpandEventHandler(h), 
                    h => el.MasterRowCollapsing += h, 
                    h => el.MasterRowCollapsing -= h
                );
        }
                        
        public static IObservable<IEvent<CustomMasterRowEventArgs>> GetMasterRowCollapsed (this GridView el)
        {
            return Observable.FromEvent<CustomMasterRowEventHandler, CustomMasterRowEventArgs>
                (   
                    h => new CustomMasterRowEventHandler(h), 
                    h => el.MasterRowCollapsed += h, 
                    h => el.MasterRowCollapsed -= h
                );
        }
                        
        public static IObservable<IEvent<MasterRowGetLevelDefaultViewEventArgs>> GetMasterRowGetLevelDefaultView (this GridView el)
        {
            return Observable.FromEvent<MasterRowGetLevelDefaultViewEventHandler, MasterRowGetLevelDefaultViewEventArgs>
                (   
                    h => new MasterRowGetLevelDefaultViewEventHandler(h), 
                    h => el.MasterRowGetLevelDefaultView += h, 
                    h => el.MasterRowGetLevelDefaultView -= h
                );
        }
                        
        public static IObservable<IEvent<MasterRowGetChildListEventArgs>> GetMasterRowGetChildList (this GridView el)
        {
            return Observable.FromEvent<MasterRowGetChildListEventHandler, MasterRowGetChildListEventArgs>
                (   
                    h => new MasterRowGetChildListEventHandler(h), 
                    h => el.MasterRowGetChildList += h, 
                    h => el.MasterRowGetChildList -= h
                );
        }
                        
        public static IObservable<IEvent<MasterRowGetRelationNameEventArgs>> GetMasterRowGetRelationName (this GridView el)
        {
            return Observable.FromEvent<MasterRowGetRelationNameEventHandler, MasterRowGetRelationNameEventArgs>
                (   
                    h => new MasterRowGetRelationNameEventHandler(h), 
                    h => el.MasterRowGetRelationName += h, 
                    h => el.MasterRowGetRelationName -= h
                );
        }
                        
        public static IObservable<IEvent<MasterRowGetRelationNameEventArgs>> GetMasterRowGetRelationDisplayCaption (this GridView el)
        {
            return Observable.FromEvent<MasterRowGetRelationNameEventHandler, MasterRowGetRelationNameEventArgs>
                (   
                    h => new MasterRowGetRelationNameEventHandler(h), 
                    h => el.MasterRowGetRelationDisplayCaption += h, 
                    h => el.MasterRowGetRelationDisplayCaption -= h
                );
        }
                        
        public static IObservable<IEvent<MasterRowGetRelationCountEventArgs>> GetMasterRowGetRelationCount (this GridView el)
        {
            return Observable.FromEvent<MasterRowGetRelationCountEventHandler, MasterRowGetRelationCountEventArgs>
                (   
                    h => new MasterRowGetRelationCountEventHandler(h), 
                    h => el.MasterRowGetRelationCount += h, 
                    h => el.MasterRowGetRelationCount -= h
                );
        }
                        
        public static IObservable<IEvent<CustomRowCellEditEventArgs>> GetCustomRowCellEdit (this GridView el)
        {
            return Observable.FromEvent<CustomRowCellEditEventHandler, CustomRowCellEditEventArgs>
                (   
                    h => new CustomRowCellEditEventHandler(h), 
                    h => el.CustomRowCellEdit += h, 
                    h => el.CustomRowCellEdit -= h
                );
        }
                        
        public static IObservable<IEvent<CustomRowCellEditEventArgs>> GetCustomRowCellEditForEditing (this GridView el)
        {
            return Observable.FromEvent<CustomRowCellEditEventHandler, CustomRowCellEditEventArgs>
                (   
                    h => new CustomRowCellEditEventHandler(h), 
                    h => el.CustomRowCellEditForEditing += h, 
                    h => el.CustomRowCellEditForEditing -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetLeftCoordChanged (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.LeftCoordChanged += h, 
                    h => el.LeftCoordChanged -= h
                );
        }
                        
        public static IObservable<IEvent<ColumnEventArgs>> GetColumnWidthChanged (this GridView el)
        {
            return Observable.FromEvent<ColumnEventHandler, ColumnEventArgs>
                (   
                    h => new ColumnEventHandler(h), 
                    h => el.ColumnWidthChanged += h, 
                    h => el.ColumnWidthChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetTopRowChanged (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.TopRowChanged += h, 
                    h => el.TopRowChanged -= h
                );
        }
                        
        public static IObservable<IEvent<GridMenuItemClickEventArgs>> GetGridMenuItemClick (this GridView el)
        {
            return Observable.FromEvent<GridMenuItemClickEventHandler, GridMenuItemClickEventArgs>
                (   
                    h => new GridMenuItemClickEventHandler(h), 
                    h => el.GridMenuItemClick += h, 
                    h => el.GridMenuItemClick -= h
                );
        }
                        
        public static IObservable<IEvent<GridMenuEventArgs>> GetShowGridMenu (this GridView el)
        {
            return Observable.FromEvent<GridMenuEventHandler, GridMenuEventArgs>
                (   
                    h => new GridMenuEventHandler(h), 
                    h => el.ShowGridMenu += h, 
                    h => el.ShowGridMenu -= h
                );
        }
                        
        public static IObservable<IEvent<PopupMenuShowingEventArgs>> GetPopupMenuShowing (this GridView el)
        {
            return Observable.FromEvent<PopupMenuShowingEventHandler, PopupMenuShowingEventArgs>
                (   
                    h => new PopupMenuShowingEventHandler(h), 
                    h => el.PopupMenuShowing += h, 
                    h => el.PopupMenuShowing -= h
                );
        }
                        
        public static IObservable<IEvent<RowHeightEventArgs>> GetCalcRowHeight (this GridView el)
        {
            return Observable.FromEvent<RowHeightEventHandler, RowHeightEventArgs>
                (   
                    h => new RowHeightEventHandler(h), 
                    h => el.CalcRowHeight += h, 
                    h => el.CalcRowHeight -= h
                );
        }
                        
        public static IObservable<IEvent<CustomSummaryEventArgs>> GetCustomSummaryCalculate (this GridView el)
        {
            return Observable.FromEvent<CustomSummaryEventHandler, CustomSummaryEventArgs>
                (   
                    h => new CustomSummaryEventHandler(h), 
                    h => el.CustomSummaryCalculate += h, 
                    h => el.CustomSummaryCalculate -= h
                );
        }
                        
        public static IObservable<IEvent<CustomSummaryExistEventArgs>> GetCustomSummaryExists (this GridView el)
        {
            return Observable.FromEvent<CustomSummaryExistEventHandler, CustomSummaryExistEventArgs>
                (   
                    h => new CustomSummaryExistEventHandler(h), 
                    h => el.CustomSummaryExists += h, 
                    h => el.CustomSummaryExists -= h
                );
        }
                        
        public static IObservable<IEvent<CalcPreviewTextEventArgs>> GetCalcPreviewText (this GridView el)
        {
            return Observable.FromEvent<CalcPreviewTextEventHandler, CalcPreviewTextEventArgs>
                (   
                    h => new CalcPreviewTextEventHandler(h), 
                    h => el.CalcPreviewText += h, 
                    h => el.CalcPreviewText -= h
                );
        }
                        
        public static IObservable<IEvent<RowHeightEventArgs>> GetMeasurePreviewHeight (this GridView el)
        {
            return Observable.FromEvent<RowHeightEventHandler, RowHeightEventArgs>
                (   
                    h => new RowHeightEventHandler(h), 
                    h => el.MeasurePreviewHeight += h, 
                    h => el.MeasurePreviewHeight -= h
                );
        }
                        
        public static IObservable<IEvent<RowEventArgs>> GetGroupRowExpanded (this GridView el)
        {
            return Observable.FromEvent<RowEventHandler, RowEventArgs>
                (   
                    h => new RowEventHandler(h), 
                    h => el.GroupRowExpanded += h, 
                    h => el.GroupRowExpanded -= h
                );
        }
                        
        public static IObservable<IEvent<RowEventArgs>> GetGroupRowCollapsed (this GridView el)
        {
            return Observable.FromEvent<RowEventHandler, RowEventArgs>
                (   
                    h => new RowEventHandler(h), 
                    h => el.GroupRowCollapsed += h, 
                    h => el.GroupRowCollapsed -= h
                );
        }
                        
        public static IObservable<IEvent<RowAllowEventArgs>> GetGroupRowCollapsing (this GridView el)
        {
            return Observable.FromEvent<RowAllowEventHandler, RowAllowEventArgs>
                (   
                    h => new RowAllowEventHandler(h), 
                    h => el.GroupRowCollapsing += h, 
                    h => el.GroupRowCollapsing -= h
                );
        }
                        
        public static IObservable<IEvent<RowAllowEventArgs>> GetGroupRowExpanding (this GridView el)
        {
            return Observable.FromEvent<RowAllowEventHandler, RowAllowEventArgs>
                (   
                    h => new RowAllowEventHandler(h), 
                    h => el.GroupRowExpanding += h, 
                    h => el.GroupRowExpanding -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetShowCustomizationForm (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ShowCustomizationForm += h, 
                    h => el.ShowCustomizationForm -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetHideCustomizationForm (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.HideCustomizationForm += h, 
                    h => el.HideCustomizationForm -= h
                );
        }
                        
        public static IObservable<IEvent<CustomColumnSortEventArgs>> GetCustomColumnGroup (this GridView el)
        {
            return Observable.FromEvent<CustomColumnSortEventHandler, CustomColumnSortEventArgs>
                (   
                    h => new CustomColumnSortEventHandler(h), 
                    h => el.CustomColumnGroup += h, 
                    h => el.CustomColumnGroup -= h
                );
        }
                        
        public static IObservable<IEvent<SelectionChangedEventArgs>> GetSelectionChanged (this GridView el)
        {
            return Observable.FromEvent<SelectionChangedEventHandler, SelectionChangedEventArgs>
                (   
                    h => new SelectionChangedEventHandler(h), 
                    h => el.SelectionChanged += h, 
                    h => el.SelectionChanged -= h
                );
        }
                        
        public static IObservable<IEvent<CustomDrawEventArgs>> GetCustomDrawEmptyForeground (this GridView el)
        {
            return Observable.FromEvent<CustomDrawEventHandler, CustomDrawEventArgs>
                (   
                    h => new CustomDrawEventHandler(h), 
                    h => el.CustomDrawEmptyForeground += h, 
                    h => el.CustomDrawEmptyForeground -= h
                );
        }
                        
        public static IObservable<IEvent<CancelEventArgs>> GetShowingEditor (this GridView el)
        {
            return Observable.FromEvent<CancelEventHandler, CancelEventArgs>
                (   
                    h => new CancelEventHandler(h), 
                    h => el.ShowingEditor += h, 
                    h => el.ShowingEditor -= h
                );
        }
                        
        public static IObservable<IEvent<InitNewRowEventArgs>> GetInitNewRow (this GridView el)
        {
            return Observable.FromEvent<InitNewRowEventHandler, InitNewRowEventArgs>
                (   
                    h => new InitNewRowEventHandler(h), 
                    h => el.InitNewRow += h, 
                    h => el.InitNewRow -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetHiddenEditor (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.HiddenEditor += h, 
                    h => el.HiddenEditor -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetShownEditor (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ShownEditor += h, 
                    h => el.ShownEditor -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetStartSorting (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.StartSorting += h, 
                    h => el.StartSorting -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetEndSorting (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.EndSorting += h, 
                    h => el.EndSorting -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetStartGrouping (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.StartGrouping += h, 
                    h => el.StartGrouping -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetEndGrouping (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.EndGrouping += h, 
                    h => el.EndGrouping -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetColumnChanged (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ColumnChanged += h, 
                    h => el.ColumnChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetColumnPositionChanged (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ColumnPositionChanged += h, 
                    h => el.ColumnPositionChanged -= h
                );
        }
                        
        public static IObservable<IEvent<FocusedRowChangedEventArgs>> GetFocusedRowChanged (this GridView el)
        {
            return Observable.FromEvent<FocusedRowChangedEventHandler, FocusedRowChangedEventArgs>
                (   
                    h => new FocusedRowChangedEventHandler(h), 
                    h => el.FocusedRowChanged += h, 
                    h => el.FocusedRowChanged -= h
                );
        }
                        
        public static IObservable<IEvent<FocusedColumnChangedEventArgs>> GetFocusedColumnChanged (this GridView el)
        {
            return Observable.FromEvent<FocusedColumnChangedEventHandler, FocusedColumnChangedEventArgs>
                (   
                    h => new FocusedColumnChangedEventHandler(h), 
                    h => el.FocusedColumnChanged += h, 
                    h => el.FocusedColumnChanged -= h
                );
        }
                        
        public static IObservable<IEvent<CellValueChangedEventArgs>> GetCellValueChanged (this GridView el)
        {
            return Observable.FromEvent<CellValueChangedEventHandler, CellValueChangedEventArgs>
                (   
                    h => new CellValueChangedEventHandler(h), 
                    h => el.CellValueChanged += h, 
                    h => el.CellValueChanged -= h
                );
        }
                        
        public static IObservable<IEvent<CellValueChangedEventArgs>> GetCellValueChanging (this GridView el)
        {
            return Observable.FromEvent<CellValueChangedEventHandler, CellValueChangedEventArgs>
                (   
                    h => new CellValueChangedEventHandler(h), 
                    h => el.CellValueChanging += h, 
                    h => el.CellValueChanging -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDataManagerReset (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.DataManagerReset += h, 
                    h => el.DataManagerReset -= h
                );
        }
                        
        public static IObservable<IEvent<RowCellAlignmentEventArgs>> GetRowCellDefaultAlignment (this GridView el)
        {
            return Observable.FromEvent<RowCellAlignmentEventHandler, RowCellAlignmentEventArgs>
                (   
                    h => new RowCellAlignmentEventHandler(h), 
                    h => el.RowCellDefaultAlignment += h, 
                    h => el.RowCellDefaultAlignment -= h
                );
        }
                        
        public static IObservable<IEvent<InvalidRowExceptionEventArgs>> GetInvalidRowException (this GridView el)
        {
            return Observable.FromEvent<InvalidRowExceptionEventHandler, InvalidRowExceptionEventArgs>
                (   
                    h => new InvalidRowExceptionEventHandler(h), 
                    h => el.InvalidRowException += h, 
                    h => el.InvalidRowException -= h
                );
        }
                        
        public static IObservable<IEvent<RowAllowEventArgs>> GetBeforeLeaveRow (this GridView el)
        {
            return Observable.FromEvent<RowAllowEventHandler, RowAllowEventArgs>
                (   
                    h => new RowAllowEventHandler(h), 
                    h => el.BeforeLeaveRow += h, 
                    h => el.BeforeLeaveRow -= h
                );
        }
                        
        public static IObservable<IEvent<ValidateRowEventArgs>> GetValidateRow (this GridView el)
        {
            return Observable.FromEvent<ValidateRowEventHandler, ValidateRowEventArgs>
                (   
                    h => new ValidateRowEventHandler(h), 
                    h => el.ValidateRow += h, 
                    h => el.ValidateRow -= h
                );
        }
                        
        public static IObservable<IEvent<RowObjectEventArgs>> GetRowUpdated (this GridView el)
        {
            return Observable.FromEvent<RowObjectEventHandler, RowObjectEventArgs>
                (   
                    h => new RowObjectEventHandler(h), 
                    h => el.RowUpdated += h, 
                    h => el.RowUpdated -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetColumnFilterChanged (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.ColumnFilterChanged += h, 
                    h => el.ColumnFilterChanged -= h
                );
        }
                        
        public static IObservable<IEvent<FilterPopupListBoxEventArgs>> GetShowFilterPopupListBox (this GridView el)
        {
            return Observable.FromEvent<FilterPopupListBoxEventHandler, FilterPopupListBoxEventArgs>
                (   
                    h => new FilterPopupListBoxEventHandler(h), 
                    h => el.ShowFilterPopupListBox += h, 
                    h => el.ShowFilterPopupListBox -= h
                );
        }
                        
        public static IObservable<IEvent<FilterPopupDateEventArgs>> GetShowFilterPopupDate (this GridView el)
        {
            return Observable.FromEvent<FilterPopupDateEventHandler, FilterPopupDateEventArgs>
                (   
                    h => new FilterPopupDateEventHandler(h), 
                    h => el.ShowFilterPopupDate += h, 
                    h => el.ShowFilterPopupDate -= h
                );
        }
                        
        public static IObservable<IEvent<FilterPopupCheckedListBoxEventArgs>> GetShowFilterPopupCheckedListBox (this GridView el)
        {
            return Observable.FromEvent<FilterPopupCheckedListBoxEventHandler, FilterPopupCheckedListBoxEventArgs>
                (   
                    h => new FilterPopupCheckedListBoxEventHandler(h), 
                    h => el.ShowFilterPopupCheckedListBox += h, 
                    h => el.ShowFilterPopupCheckedListBox -= h
                );
        }
                        
        public static IObservable<IEvent<CustomFilterDialogEventArgs>> GetCustomFilterDialog (this GridView el)
        {
            return Observable.FromEvent<CustomFilterDialogEventHandler, CustomFilterDialogEventArgs>
                (   
                    h => new CustomFilterDialogEventHandler(h), 
                    h => el.CustomFilterDialog += h, 
                    h => el.CustomFilterDialog -= h
                );
        }
                        
        public static IObservable<IEvent<ConvertEditValueEventArgs>> GetCustomFilterDisplayText (this GridView el)
        {
            return Observable.FromEvent<ConvertEditValueEventHandler, ConvertEditValueEventArgs>
                (   
                    h => new ConvertEditValueEventHandler(h), 
                    h => el.CustomFilterDisplayText += h, 
                    h => el.CustomFilterDisplayText -= h
                );
        }
                        
        public static IObservable<IEvent<FilterControlEventArgs>> GetFilterEditorCreated (this GridView el)
        {
            return Observable.FromEvent<FilterControlEventHandler, FilterControlEventArgs>
                (   
                    h => new FilterControlEventHandler(h), 
                    h => el.FilterEditorCreated += h, 
                    h => el.FilterEditorCreated -= h
                );
        }
                        
        public static IObservable<IEvent<UnboundExpressionEditorEventArgs>> GetUnboundExpressionEditorCreated (this GridView el)
        {
            return Observable.FromEvent<UnboundExpressionEditorEventHandler, UnboundExpressionEditorEventArgs>
                (   
                    h => new UnboundExpressionEditorEventHandler(h), 
                    h => el.UnboundExpressionEditorCreated += h, 
                    h => el.UnboundExpressionEditorCreated -= h
                );
        }
                        
        public static IObservable<IEvent<CustomDrawObjectEventArgs>> GetCustomDrawFilterPanel (this GridView el)
        {
            return Observable.FromEvent<CustomDrawObjectEventHandler, CustomDrawObjectEventArgs>
                (   
                    h => new CustomDrawObjectEventHandler(h), 
                    h => el.CustomDrawFilterPanel += h, 
                    h => el.CustomDrawFilterPanel -= h
                );
        }
                        
        public static IObservable<IEvent<CustomColumnSortEventArgs>> GetCustomColumnSort (this GridView el)
        {
            return Observable.FromEvent<CustomColumnSortEventHandler, CustomColumnSortEventArgs>
                (   
                    h => new CustomColumnSortEventHandler(h), 
                    h => el.CustomColumnSort += h, 
                    h => el.CustomColumnSort -= h
                );
        }
                        
        public static IObservable<IEvent<CustomColumnDataEventArgs>> GetCustomUnboundColumnData (this GridView el)
        {
            return Observable.FromEvent<CustomColumnDataEventHandler, CustomColumnDataEventArgs>
                (   
                    h => new CustomColumnDataEventHandler(h), 
                    h => el.CustomUnboundColumnData += h, 
                    h => el.CustomUnboundColumnData -= h
                );
        }
                        
        public static IObservable<IEvent<RowFilterEventArgs>> GetCustomRowFilter (this GridView el)
        {
            return Observable.FromEvent<RowFilterEventHandler, RowFilterEventArgs>
                (   
                    h => new RowFilterEventHandler(h), 
                    h => el.CustomRowFilter += h, 
                    h => el.CustomRowFilter -= h
                );
        }
                        
        public static IObservable<IEvent<RowEventArgs>> GetRowLoaded (this GridView el)
        {
            return Observable.FromEvent<RowEventHandler, RowEventArgs>
                (   
                    h => new RowEventHandler(h), 
                    h => el.RowLoaded += h, 
                    h => el.RowLoaded -= h
                );
        }
                        
        public static IObservable<IEvent<RowEventArgs>> GetFocusedRowLoaded (this GridView el)
        {
            return Observable.FromEvent<RowEventHandler, RowEventArgs>
                (   
                    h => new RowEventHandler(h), 
                    h => el.FocusedRowLoaded += h, 
                    h => el.FocusedRowLoaded -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetAsyncCompleted (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.AsyncCompleted += h, 
                    h => el.AsyncCompleted -= h
                );
        }
                        
        public static IObservable<IEvent<CustomColumnDisplayTextEventArgs>> GetCustomColumnDisplayText (this GridView el)
        {
            return Observable.FromEvent<CustomColumnDisplayTextEventHandler, CustomColumnDisplayTextEventArgs>
                (   
                    h => new CustomColumnDisplayTextEventHandler(h), 
                    h => el.CustomColumnDisplayText += h, 
                    h => el.CustomColumnDisplayText -= h
                );
        }
                        
        public static IObservable<IEvent<LayoutUpgadeEventArgs>> GetLayoutUpgrade (this GridView el)
        {
            return Observable.FromEvent<LayoutUpgadeEventHandler, LayoutUpgadeEventArgs>
                (   
                    h => new LayoutUpgadeEventHandler(h), 
                    h => el.LayoutUpgrade += h, 
                    h => el.LayoutUpgrade -= h
                );
        }
                        
        public static IObservable<IEvent<LayoutAllowEventArgs>> GetBeforeLoadLayout (this GridView el)
        {
            return Observable.FromEvent<LayoutAllowEventHandler, LayoutAllowEventArgs>
                (   
                    h => new LayoutAllowEventHandler(h), 
                    h => el.BeforeLoadLayout += h, 
                    h => el.BeforeLoadLayout -= h
                );
        }
                        
        public static IObservable<IEvent<KeyEventArgs>> GetKeyDown (this GridView el)
        {
            return Observable.FromEvent<KeyEventHandler, KeyEventArgs>
                (   
                    h => new KeyEventHandler(h), 
                    h => el.KeyDown += h, 
                    h => el.KeyDown -= h
                );
        }
                        
        public static IObservable<IEvent<KeyEventArgs>> GetKeyUp (this GridView el)
        {
            return Observable.FromEvent<KeyEventHandler, KeyEventArgs>
                (   
                    h => new KeyEventHandler(h), 
                    h => el.KeyUp += h, 
                    h => el.KeyUp -= h
                );
        }
                        
        public static IObservable<IEvent<KeyPressEventArgs>> GetKeyPress (this GridView el)
        {
            return Observable.FromEvent<KeyPressEventHandler, KeyPressEventArgs>
                (   
                    h => new KeyPressEventHandler(h), 
                    h => el.KeyPress += h, 
                    h => el.KeyPress -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseDown (this GridView el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseDown += h, 
                    h => el.MouseDown -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseUp (this GridView el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseUp += h, 
                    h => el.MouseUp -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseWheel (this GridView el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseWheel += h, 
                    h => el.MouseWheel -= h
                );
        }
                        
        public static IObservable<IEvent<MouseEventArgs>> GetMouseMove (this GridView el)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>
                (   
                    h => new MouseEventHandler(h), 
                    h => el.MouseMove += h, 
                    h => el.MouseMove -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetMouseEnter (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.MouseEnter += h, 
                    h => el.MouseEnter -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetMouseLeave (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.MouseLeave += h, 
                    h => el.MouseLeave -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetClick (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Click += h, 
                    h => el.Click -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDoubleClick (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.DoubleClick += h, 
                    h => el.DoubleClick -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetLostFocus (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.LostFocus += h, 
                    h => el.LostFocus -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetGotFocus (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.GotFocus += h, 
                    h => el.GotFocus -= h
                );
        }
                        
        public static IObservable<IEvent<BaseContainerValidateEditorEventArgs>> GetValidatingEditor (this GridView el)
        {
            return Observable.FromEvent<BaseContainerValidateEditorEventHandler, BaseContainerValidateEditorEventArgs>
                (   
                    h => new BaseContainerValidateEditorEventHandler(h), 
                    h => el.ValidatingEditor += h, 
                    h => el.ValidatingEditor -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDataSourceChanged (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.DataSourceChanged += h, 
                    h => el.DataSourceChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetRowCountChanged (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.RowCountChanged += h, 
                    h => el.RowCountChanged -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetLayout (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Layout += h, 
                    h => el.Layout -= h
                );
        }
                        
        public static IObservable<IEvent<InvalidValueExceptionEventArgs>> GetInvalidValueException (this GridView el)
        {
            return Observable.FromEvent<InvalidValueExceptionEventHandler, InvalidValueExceptionEventArgs>
                (   
                    h => new InvalidValueExceptionEventHandler(h), 
                    h => el.InvalidValueException += h, 
                    h => el.InvalidValueException -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDisposed (this GridView el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Disposed += h, 
                    h => el.Disposed -= h
                );
        }
    }

public static class ToolTipControllerExtensions 
	{
		                    
        public static IObservable<IEvent<ToolTipControllerGetActiveObjectInfoEventArgs>> GetGetActiveObjectInfo (this ToolTipController el)
        {
            return Observable.FromEvent<ToolTipControllerGetActiveObjectInfoEventHandler, ToolTipControllerGetActiveObjectInfoEventArgs>
                (   
                    h => new ToolTipControllerGetActiveObjectInfoEventHandler(h), 
                    h => el.GetActiveObjectInfo += h, 
                    h => el.GetActiveObjectInfo -= h
                );
        }
                        
        public static IObservable<IEvent<ToolTipControllerShowEventArgs>> GetBeforeShow (this ToolTipController el)
        {
            return Observable.FromEvent<ToolTipControllerBeforeShowEventHandler, ToolTipControllerShowEventArgs>
                (   
                    h => new ToolTipControllerBeforeShowEventHandler(h), 
                    h => el.BeforeShow += h, 
                    h => el.BeforeShow -= h
                );
        }
                        
        public static IObservable<IEvent<ToolTipControllerCalcSizeEventArgs>> GetCalcSize (this ToolTipController el)
        {
            return Observable.FromEvent<ToolTipControllerCalcSizeEventHandler, ToolTipControllerCalcSizeEventArgs>
                (   
                    h => new ToolTipControllerCalcSizeEventHandler(h), 
                    h => el.CalcSize += h, 
                    h => el.CalcSize -= h
                );
        }
                        
        public static IObservable<IEvent<ToolTipControllerCustomDrawEventArgs>> GetCustomDraw (this ToolTipController el)
        {
            return Observable.FromEvent<ToolTipControllerCustomDrawEventHandler, ToolTipControllerCustomDrawEventArgs>
                (   
                    h => new ToolTipControllerCustomDrawEventHandler(h), 
                    h => el.CustomDraw += h, 
                    h => el.CustomDraw -= h
                );
        }
                        
        public static IObservable<IEvent<EventArgs>> GetDisposed (this ToolTipController el)
        {
            return Observable.FromEvent<EventHandler, EventArgs>
                (   
                    h => new EventHandler(h), 
                    h => el.Disposed += h, 
                    h => el.Disposed -= h
                );
        }
    }
}