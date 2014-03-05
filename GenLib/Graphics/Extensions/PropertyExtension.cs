using System.ComponentModel;

namespace Atlas.Extensions
{
    public static class PropertyExtension
    {
        public static void Raise(this PropertyChangedEventHandler handler, string propertyName)
        {
            if (handler != null) handler(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}