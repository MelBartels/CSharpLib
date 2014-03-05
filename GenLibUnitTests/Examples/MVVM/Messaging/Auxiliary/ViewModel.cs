using System;
using System.Linq;
using GenLib.Messaging;
using GenLib.View;

namespace GenLibUnitTests.Examples.MVVM.Messaging.Auxiliary
{
    public class ViewModel : IViewModel
    {
        public Action Update;
        public string MirroredText { get; set; }
        public string CopiedText { get; set; }
        public MessageToken TitleToken { get; set; }

        #region IViewModel Members

        public void Subscribe()
        {
            Messenger.Instance().OfType<StringMessage>()
                .Where(m => m.Token == TitleToken)
                .Subscribe(p =>
                               {
                                   MirroredText = p.Value;
                                   Update();
                               });

            Messenger.Instance().OfType<CopyTextMessage>()
                .Subscribe(m =>
                               {
                                   CopiedText = m.Value;
                                   Update();
                               });
        }

        #endregion
    }
}