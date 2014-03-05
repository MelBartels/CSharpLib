using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GenLibUnitTests.Reactive.MouseDemo.Initial
{
    internal static class Extensions
    {
        internal static IObservable<IEvent<MouseEventArgs>> GetMouseDownS(this Control control)
        {
            return Observable.FromEvent<MouseEventArgs>(control, "MouseDown");
        }

        internal static IObservable<IEvent<MouseEventArgs>> GetMouseUpS(this Control control)
        {
            return Observable.FromEvent<MouseEventArgs>(control, "MouseUp");
        }

        internal static IObservable<IEvent<MouseEventArgs>> GetMouseMoveS(this Control control)
        {
            return Observable.FromEvent<MouseEventArgs>(control, "MouseMove");
        }
    }
}