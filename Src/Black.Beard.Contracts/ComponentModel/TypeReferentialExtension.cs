using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.ComponentModel
{
    public static class TypeReferentialExtension
    {


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
                .Select(c => new KeyValuePair<string, Type>(c.GetCustomAttributes(true).OfType<Attributes.ExposeClassAttribute>().FirstOrDefault().DisplayName, c))
                .ToArray();
        }


    }

}