using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GenLib.View
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private readonly Dictionary<Type, PropertyComparer<T>> _comparers;

        public SortableBindingList()
            : base(new List<T>())
        {
            _comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        public SortableBindingList(IEnumerable<T> enumeration)
            : base(new List<T>(enumeration))
        {
            _comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        private bool IsSorted { get; set; }
        private ListSortDirection ListSortDirection { get; set; }
        private PropertyDescriptor PropertyDescriptor { get; set; }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return IsSorted; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return PropertyDescriptor; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return ListSortDirection; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            var itemsList = (List<T>) Items;

            var propertyType = property.PropertyType;
            PropertyComparer<T> comparer;
            if (!_comparers.TryGetValue(propertyType, out comparer))
            {
                comparer = new PropertyComparer<T>(property, direction);
                _comparers.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndDirection(property, direction);
            itemsList.Sort(comparer);

            PropertyDescriptor = property;
            ListSortDirection = direction;
            IsSorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            IsSorted = false;
            PropertyDescriptor = base.SortPropertyCore;
            ListSortDirection = base.SortDirectionCore;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            var count = Count;
            for (var i = 0; i < count; ++i)
            {
                var element = this[i];
                if (property.GetValue(element).Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}