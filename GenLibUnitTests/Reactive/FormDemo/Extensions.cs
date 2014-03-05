using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GenLibUnitTests.Reactive.FormDemo
{
    public static class Extensions
    {
        public static IObservable<IEvent<EventArgs>> GetLoad(this Form form)
        {
            return Observable.FromEvent<EventHandler, EventArgs>(handler => new EventHandler(handler),
                                                                 handler => form.Load += handler,
                                                                 handler => form.Load -= handler);
        }

        public static IObservable<IEvent<EventArgs>> GetClicks(this Control control)
        {
            return Observable.FromEvent<EventHandler, EventArgs>(handler => new EventHandler(handler),
                                                                 handler => control.Click += handler,
                                                                 handler => control.Click -= handler);
        }

        public static IObservable<IEvent<MouseEventArgs>> GetMouseDown(this Control control)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>(handler => new MouseEventHandler(handler),
                                                                           handler => control.MouseDown += handler,
                                                                           handler => control.MouseDown -= handler);
        }

        public static IObservable<IEvent<MouseEventArgs>> GetMouseUp(this Control control)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>(handler => new MouseEventHandler(handler),
                                                                           handler => control.MouseUp += handler,
                                                                           handler => control.MouseUp -= handler);
        }

        public static IObservable<IEvent<MouseEventArgs>> GetMouseMove(this Control control)
        {
            return Observable.FromEvent<MouseEventHandler, MouseEventArgs>(handler => new MouseEventHandler(handler),
                                                                           handler => control.MouseMove += handler,
                                                                           handler => control.MouseMove -= handler);
        }
    }
}