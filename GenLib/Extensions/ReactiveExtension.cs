using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GenLib.Extensions
{
    public static class ReactiveExtension
    {
        public static PropertyDescriptor GetPropertyDescriptor<TIn, TOut>(this TIn target, Expression<Func<TIn, TOut>> property)
        {
            if (target.Equals(null))
                throw new ArgumentException("TIn target cannot be null");
            if (property == null)
                throw new ArgumentException("Expression<Func<TIn, TOut>> property cannot be null");

            var body = property.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The expression does not reference a property.");

            var propertyInfo = body.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException("The expression does not reference a property.");

            var propertyName = propertyInfo.Name;
            var propertyDescriptor = (TypeDescriptor.GetProperties(target)
                .Cast<PropertyDescriptor>()
                .Where(p => string.Equals(p.Name, propertyName, StringComparison.Ordinal)))
                .Single();
            return propertyDescriptor;
        }

        public static IObservable<TOut> FromPropertyChanged<TIn, TOut>(this TIn target, Expression<Func<TIn, TOut>> property)
        {
            if (target.Equals(null))
                throw new ArgumentException("TIn target cannot be null");
            if (property == null)
                throw new ArgumentException("Expression<Func<TIn, TOut>> property cannot be null");

            var body = property.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The expression does not reference a property.");

            var propertyInfo = body.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException("The expression does not reference a property.");

            var propertyName = propertyInfo.Name;
            var propertyDescriptor = (TypeDescriptor.GetProperties(target)
                .Cast<PropertyDescriptor>()
                .Where(p => string.Equals(p.Name, propertyName, StringComparison.Ordinal)))
                .Single();

            if (!propertyDescriptor.SupportsChangeEvents)
                throw new ArgumentException("The property does not support change events.");

            var getter = property.Compile();

            return Observable.FromEvent<EventHandler, EventArgs>(d => d.Invoke,
                                                                 h => propertyDescriptor.AddValueChanged(target, h),
                                                                 h => propertyDescriptor.RemoveValueChanged(target, h))
                .Select(e => getter(target));
        }
    }
}