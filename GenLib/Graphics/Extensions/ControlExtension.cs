using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Atlas.Extensions
{
    public static class ControlExtension
    {
        /// <summary>
        /// <para>TextBox Extension.</para>
        /// <para>Moves cursor to end of text</para>
        /// <para>eg, TextBox1.MoveCursorToEnd()</para>
        /// </summary>
        public static void MoveCursorToEnd(this TextBox textBox)
        {
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }

        /// <summary>
        /// <para>MouseMove/MouseDown/MouseUp Extension.</para>
        /// <para>Gets the mouse position. Dragging the mouse cursor results in a stream of mouse positions</para>
        /// <para>eg, Control.GetMouseDrag(mouseEventArgs => Text = @"mouse position is " + mouseEventArgs.Location.ToString());</para>
        /// </summary>
        public static void GetMouseDrag<T>(this T t, Action<Point> action)
            where T : Control
        {
            // SelectMany() means that each MouseDown results in a new sequence of MouseMove()
            t.GetMouseDown()
                .SelectMany(start => t.GetMouseMove().StartWith(start).TakeUntil(t.GetMouseUp()))
                .Subscribe(e => action(e.EventArgs.Location));
        }

        /// <summary>
        /// <para>MouseMove/MouseDown/MouseUp Extension.</para>
        /// <para>Gets the change in X, Y from last mouse position. Dragging the mouse cursor results in a stream of delta X, Y's</para>
        /// <para>eg, Control.GetMouseDragDelta(size => Text = @"change in mouse position is " + size.ToString());</para>
        /// </summary>
        public static void GetMouseDragDelta<T>(this T t, Action<Size> action)
            where T : Control
        {
            var deltas = from pair in t.GetMouseMove().BufferWithCount(2)
                         let array = pair.ToArray()
                         let a = array[0].EventArgs.Location
                         let b = array[1].EventArgs.Location
                         select new Size(b.X - a.X, b.Y - a.Y);
            deltas
                .SkipUntil(t.GetMouseDown())
                .TakeUntil(t.GetMouseUp())
                .Repeat()
                .Subscribe(action);
        }

        /// <summary>
        /// <para>MouseMove/MouseDown/MouseUp Extension.</para>
        /// <para>Gets the starting and current mouse positions. Dragging the mouse cursor results in a series of starting and current mouse positions</para>
        /// <para>eg, ControlGetMouseDragStartCurrent((s, c) => label1.Text = @"mouse started at " + s.ToString() + @", now at " + c.ToString());</para>
        /// </summary>
        public static void GetMouseDragStartCurrent<T>(this T t, Action<Point, Point> action)
            where T : Control
        {
            t.GetMouseDown()
                .SelectMany(start => t.GetMouseMove().StartWith(start).TakeUntil(t.GetMouseUp()),
                            (start, current) => new {Start = start, Current = current})
                .Subscribe(pts => action(pts.Start.EventArgs.Location, pts.Current.EventArgs.Location));
        }

        /// <summary>
        /// <para>Form Extension.</para>
        /// <para>Minimizes the form by executing the observable event on the desired control</para>
        /// <para>eg, this.MinimizeOn(this.GetDoubleClick()); minimizes the form when double clicking on the form</para>
        /// <para>eg, this.MinimizeOn(Label.GetDoubleClick()); minimizes the form when double clicking on the label</para>
        /// </summary>
        public static void MinimizeOn<T>(this T t, IObservable<IEvent<EventArgs>> observable)
            where T : Form
        {
            observable.Subscribe(e => t.WindowState = FormWindowState.Minimized);
        }

        /// <summary>
        /// <para>Form Extension.</para>
        /// <para>Repositions the form by dragging the mouse on the desired control</para>
        /// <para>eg, this.RepositionByDraggingOn(this); repositions the form by dragging the mouse across the form</para>
        /// <para>eg, this.RepositionByDraggingOn(Label); repositions the form by dragging the mouse across the label</para>
        /// </summary>
        public static void RepositionByDraggingOn<T1, T2>(this T1 t1, T2 t2)
            where T1 : Form
            where T2 : Control
        {
            t2.GetMouseDragDelta(
                delta => t1.Location = new Point(t1.Location.X + delta.Width, t1.Location.Y + delta.Height));
        }
    }
}