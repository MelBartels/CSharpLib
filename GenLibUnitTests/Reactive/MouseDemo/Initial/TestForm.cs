using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GenLibUnitTests.Reactive.FormDemo;

namespace GenLibUnitTests.Reactive.MouseDemo.Initial
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            //Simplest();
            ShowStartAndCurrent();
            //WithSimpleExtensions();
            //WithRigorousExtensions();
            //DeltaMousePositions();
        }

        private void Simplest()
        {
//            var answer = Observable.Return(42);
//            answer.Subscribe(v => label1.Text = v.ToString());

            // type is IObservable<Point>
            var mouseDown = Observable.FromEvent<MouseEventArgs>(this, "MouseDown")
                .Select(evt => evt.EventArgs.Location);

            var mouseUp = Observable.FromEvent<MouseEventArgs>(this, "MouseUp")
                .Select(evt => evt.EventArgs.Location);

            var mouseMove = Observable.FromEvent<MouseEventArgs>(this, "MouseMove")
                .Select(evt => evt.EventArgs.Location);

            // type is IObservable<Point>
            var series = mouseDown.SelectMany(start => mouseMove.StartWith(start).TakeUntil(mouseUp));
            series.Subscribe(point => label1.Text = point.ToString());
        }

        private void ShowStartAndCurrent()
        {
            var mouseDown = Observable.FromEvent<MouseEventArgs>(this, "MouseDown")
                .Select(evt => evt.EventArgs.Location);

            var mouseUp = Observable.FromEvent<MouseEventArgs>(this, "MouseUp")
                .Select(evt => evt.EventArgs.Location);

            var mouseMove = Observable.FromEvent<MouseEventArgs>(this, "MouseMove")
                .Select(evt => evt.EventArgs.Location);

            // projects anonymous type, therefore cannot be declared explicitly: 'var' is required
            var series = mouseDown.SelectMany(start => mouseMove.StartWith(start).TakeUntil(mouseUp),
                                              (start, current) => new {Start = start, Current = current});

            series.Subscribe(pts => label1.Text = pts.Start.ToString() + pts.Current.ToString());
        }

        private void WithSimpleExtensions()
        {
            var answer = Observable.Return(42);
            answer.Subscribe(v => label1.Text = v.ToString());

            // type is IObservable<IEvent<MouseEventArgs>>
            var series =
                this.GetMouseDownS().SelectMany(
                    start => this.GetMouseMoveS().StartWith(start).TakeUntil(this.GetMouseUpS()));

            series.Subscribe(point => DisplayMousePosition(point));
        }

        private string DisplayMousePosition(IEvent<MouseEventArgs> point)
        {
            return label1.Text = point.EventArgs.Location.ToString();
        }

        private void WithRigorousExtensions()
        {
            // type is IObservable<IEvent<MouseEventArgs>>
            var series =
                this.GetMouseDown().SelectMany(
                    start => this.GetMouseMove().StartWith(start).TakeUntil(this.GetMouseUp()));

            series.Subscribe(point => UpdateLabel(point.EventArgs.Location.ToString()));
        }

        private void DeltaMousePositions()
        {
            // methods chain requires multiple Selects()
            var deltasMethod = this.GetMouseMove().BufferWithCount(2)
                .Select(pair => new {pair, array = pair.ToArray()})
                .Select(p2 => new {p2, a = p2.array[0].EventArgs.Location})
                .Select(p3 => new {p3, b = p3.p2.array[1].EventArgs.Location})
                .Select(p4 => new Size(p4.b.X - p4.p3.a.X, p4.b.Y - p4.p3.a.Y));

            // type is IObservable<Size> 
            var deltas = from pair in this.GetMouseMove().BufferWithCount(2)
                         let array = pair.ToArray()
                         let a = array[0].EventArgs.Location
                         let b = array[1].EventArgs.Location
                         select new Size(b.X - a.X, b.Y - a.Y);

            var dragDeltas = deltas.SkipUntil(this.GetMouseDown()).TakeUntil(this.GetMouseUp()).Repeat();
            dragDeltas.Subscribe(dd => UpdateLabel(dd.ToString()));
        }

        private void UpdateLabel(string text)
        {
            label1.Text = text;
        }
    }
}