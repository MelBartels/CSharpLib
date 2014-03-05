using System.Collections.Generic;

namespace GenLib.Observer
{
    public class Observers
    {
        public delegate bool BoolObjectObserverEventsArgs(object sender, ObserverEventArgs oea);

        public Observers()
        {
            ListObservers = new List<BoolObjectObserverEventsArgs>();
        }

        private List<BoolObjectObserverEventsArgs> ListObservers { get; set; }

        public void Add(BoolObjectObserverEventsArgs observer)
        {
            ListObservers.Add(observer);
        }

        public void Remove(BoolObjectObserverEventsArgs observer)
        {
            ListObservers.Remove(observer);
        }

        public void Clear()
        {
            ListObservers.Clear();
        }

        public void Alert(object sender, ObserverEventArgs oea)
        {
            ListObservers.ForEach(observer => observer(sender, oea));
        }
    }
}