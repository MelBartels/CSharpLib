using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace GenLib.View
{
    public class PropertyComparer<T> : IComparer<T>
    {
        private readonly IComparer _comparer;

        public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
        {
            PropertyDescriptor = property;
            var comparerForPropertyType = typeof (Comparer<>).MakeGenericType(property.PropertyType);
            _comparer = comparerForPropertyType.InvokeMember("Default",
                                                             BindingFlags.Static | BindingFlags.GetProperty |
                                                             BindingFlags.Public, null, null, null) as IComparer;
            SetListSortDirection(direction);
        }

        private PropertyDescriptor PropertyDescriptor { get; set; }
        private int Reverse { get; set; }

        #region IComparer<T> Members

        public int Compare(T x, T y)
        {
            return Reverse*_comparer.Compare(PropertyDescriptor.GetValue(x), PropertyDescriptor.GetValue(y));
        }

        #endregion

        private void SetPropertyDescriptor(PropertyDescriptor descriptor)
        {
            PropertyDescriptor = descriptor;
        }

        private void SetListSortDirection(ListSortDirection direction)
        {
            Reverse = direction == ListSortDirection.Ascending ? 1 : -1;
        }

        public void SetPropertyAndDirection(PropertyDescriptor descriptor, ListSortDirection direction)
        {
            SetPropertyDescriptor(descriptor);
            SetListSortDirection(direction);
        }
    }
}