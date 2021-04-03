using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Versatil.Domain.Extensions
{
    public static class AttributesExtensions
    {
        public static string DisplayNameFor<T>(this T item, PropertyInfo propertyInfo) where T : class
        {
            return DisplayName<T>(propertyInfo);
        }

        public static string DisplayNameFor<T, TKey>(this T item, Expression<Func<T, TKey>> property) where T : class
        {
            PropertyInfo propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;
            return DisplayName<T>(propertyInfo);
        }

        private static string DisplayName<T>(PropertyInfo propertyInfo) where T : class
        {
            var displayName = "";

            if (propertyInfo != null)
            {
                var propertyName = propertyInfo.Name;
                displayName = propertyName;

                var memberInfo = typeof(T).GetProperty(propertyName);

                if (memberInfo.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute displayAttribute)
                {
                    displayName = displayAttribute.Name;
                }
                else if (memberInfo.GetCustomAttribute(typeof(DisplayNameAttribute)) is DisplayNameAttribute displayNameAttribute)
                {
                    displayName = displayNameAttribute.DisplayName;
                }
            }

            return displayName;
        }
    }
}
