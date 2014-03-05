using System;
using System.Linq;
using GenLib.Messaging;
using GenLib.View;

namespace GenLibUnitTests.Examples.MVVM.Messaging.Main
{
    public class ViewModel : IViewModel
    {
        public const string TitleKey = "Title";
        public Action Update;
        private string _newDisplayedText;
        private string _titleTextViaReactive;
        public MessageToken TitleToken { get; set; }
        private int UpdatedCount { get; set; }

        // bound properties 
        public string Title { get; set; }

        public string TitleTextViaReactive
        {
            get { return _titleTextViaReactive; }
            set
            {
                _titleTextViaReactive = value;
                Title = value;
                Messenger.Instance().Send(new StringMessage
                                              {
                                                  Token = TitleToken,
                                                  Value = value,
                                              });
                Update();
            }
        }

        public string DisplayedText { get; set; }

        public string NewDisplayedText
        {
            get { return _newDisplayedText; }
            set
            {
                _newDisplayedText = value;
                if (value == DisplayedText) return;
                DisplayedText = value;
                UpdatedText = (++UpdatedCount).ToString();
                Update();
            }
        }

        public string UpdatedText { get; set; }
        public string CopiedText { get; set; }

        #region IViewModel Members

        public void Subscribe()
        {
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