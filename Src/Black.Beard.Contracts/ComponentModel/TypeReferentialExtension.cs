using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{
    public static class TypeReferentialExtension
    {





        /// <summary>
        /// Gets the custom attribute attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static T[] GetAttributes<T>(this Type self) where T : Attribute
        {

            return TypeDescriptor.GetAttributes(self).OfType<T>().ToArray();
        }

        /// <summary>
        /// Gets the custom attribute attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static T[] GetAttributes<T>(this MethodInfo self) where T : Attribute
        {
            return TypeDescriptor.GetAttributes(self).OfType<T>().ToArray();
        }

        /// <summary>
        /// Gets the custom attribute attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static T[] GetAttributes<T>(this PropertyInfo self) where T : Attribute
        {
            return TypeDescriptor.GetAttributes(self).OfType<T>().ToArray();
        }

        /// <summary>
        /// Gets the custom attribute attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static T[] GetAttributes<T>(this FieldInfo self) where T : Attribute
        {
            return TypeDescriptor.GetAttributes(self).OfType<T>().ToArray();
        }

        /// <summary>
        /// Gets the custom attribute attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static T[] GetAttributes<T>(this EventInfo self) where T : Attribute
        {
            return TypeDescriptor.GetAttributes(self).OfType<T>().ToArray();
        }

        /// <summary>
        /// lookk for all loaded assemblies and return types where class contains <see cref="Attributes.ExposeClassAttribute"/>. with context equals specified context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self is  <see cref="ITypeReferential"/></param>
        /// <param name="context">The context that want to search in context attribute</param>
        /// <returns>the list of types found, the key is the display name of <see cref="Attributes.ExposeClassAttribute"/></returns>
        public static KeyValuePair<string, Type>[] GetTypesWithAttributeExposeClass<T>(this ITypeReferential self, string context)
        {
            return self
                .GetTypesWithAttributes<Attributes.ExposeClassAttribute>(typeof(T), attribute => attribute.Context == context)
                .Select(c => new KeyValuePair<string, Type>(TypeDescriptor.GetAttributes(c).OfType<Attributes.ExposeClassAttribute>().FirstOrDefault().Name, c))
                .ToArray();
        }


    }

}