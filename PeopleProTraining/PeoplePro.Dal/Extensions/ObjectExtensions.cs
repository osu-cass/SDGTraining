using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePro.Dal.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Copies one object to another.  The objects need not be of the same type.  The copying process matches on property name and type.  This is a shallow copy; collections will not be copied.
        /// </summary>
        /// <typeparam name="TOriginal"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="enumToString">If true, will attempt to copy properties from an Enum to a String if the property names are equal</param>
        /// <remarks>Taken from Mulnomah falls.</remarks>
        public static void CopyTo<TOriginal, TOther>(this TOriginal source, TOther destination) where TOriginal : class
        {
            if (destination == null || source == null)
            {
                return;
            }

            var sourceType = typeof(TOriginal);
            var destinationType = typeof(TOther);
            var sourceProps = CacheManager.GetPropertyInfoForType(sourceType)
                                          .Where(t => t.CanRead)
                                          .ToList();
            var destinationProps = CacheManager.GetPropertyInfoForType(destinationType)
                                               .Where(t => t.CanWrite)
                                               .ToList();

            foreach (var prop in sourceProps)
            {
                PropertyInfo destProp = destinationProps
                                        .SingleOrDefault(u => u.Name == prop.Name &&
                                                         u.PropertyType == prop.PropertyType);

                if (destProp != null)
                {
                    destProp.SetValue(destination, prop.GetValue(source));
                }
            }
        }
    }
}
