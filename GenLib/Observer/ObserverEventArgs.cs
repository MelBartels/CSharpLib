using System;
using System.Collections.Generic;

namespace GenLib.Observer
{
    public class ObserverEventArgs : EventArgs
    {
        public ObserverEventArgs()
        {
            Args = new List<object>();
        }

        public List<Object> Args { get; set; }

        public Object Arg
        {
            get { return Args[0]; }
            set
            {
                if (Args.Count == 0)
                    Args.Add(value);
                else
                    Args[0] = value;
            }
        }
    }
}