using System;
using System.Linq;
using System.Threading;
using GenLib.Extensions;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.Extension
{
    public class EventInvokeExtensions
    {
        private const string TestMessage = "sent via Extensions.InvokeExt<T> Raise<T>";
        private const string TestMessage2 = "sent via Extensions.InvokeExt<T> Raise";
        private const string TestMessage3 = "sent via Extensions.InvokeExt<T> Raise w/ no args";
        private ExtensionsForm Form { get; set; }

        public void Callback(object sender, EventArgs args)
        {
            // GenLib.Extensions.InvokeExt<T> (called from ExtensionsForm) on separate thread

            // test different .Raise extensions
            (new Thread(() => UpdateText.Raise(sender, new StringEventArgs {Message = TestMessage}))).Start();
            (new Thread(() => UpdateText2.Raise(sender, new EventArgs()))).Start();
            (new Thread(() => UpdateText3.Raise())).Start();
        }

        public event EventHandler<StringEventArgs> UpdateText;
        public event EventHandler UpdateText2;
        public event EventHandler UpdateText3;

        private void Extensions_UpdateText3(object sender, EventArgs e)
        {
            Form.UpdateText(this, new StringEventArgs {Message = TestMessage3});
        }

        [Fact]
        public void InvokeExt()
        {
            Form = new ExtensionsForm();
            Form.Load += Callback;

            // reactive framework examples
            Observable.FromEvent<StringEventArgs>(this, "UpdateText")
                .Subscribe(e => Form.UpdateText(this, e.EventArgs));

            Observable.FromEvent<EventArgs>(this, "UpdateText2")
                .Subscribe(e => Form.UpdateText(this, new StringEventArgs {Message = TestMessage2}));

            // standard event hookup example;
            // requires class level ExtensionsForm property and Extensions_UpdateText3 method
            UpdateText3 += Extensions_UpdateText3;

            (new Thread(() => Form.ShowDialog())).Start();
            Thread.Sleep(new Pause().MilliSec);

            Form.TextBoxText().IndexOf(TestMessage).ShouldBeGreaterThan(-1);
            Form.TextBoxText().IndexOf(TestMessage2).ShouldBeGreaterThan(-1);
            Form.TextBoxText().IndexOf(TestMessage3).ShouldBeGreaterThan(-1);

            Form.Close();
            Form.Load -= Callback;
            UpdateText3 -= Extensions_UpdateText3;

            Assert.True(true);
        }
    }
}