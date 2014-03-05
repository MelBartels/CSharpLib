using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GenLib.View
{
    public class ViewModelPrototype : INotifyPropertyChanged
    {
        private bool _update;
        public string MyFooProperty { get; set; }

        public bool Update
        {
            get { return _update; }
            set
            {
                _update = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Update"));
            }
        }

        public IObservable<IEvent<EventArgs>> CopyText { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}