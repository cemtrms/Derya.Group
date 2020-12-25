using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Framework.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsSubclassOfRawGeneric(this Type derivedType, Type baseType)
        {
            while (derivedType != null && derivedType != typeof(object))
            {
                var currentType = derivedType.IsGenericType ? derivedType.GetGenericTypeDefinition() : derivedType;
                if (baseType == currentType)
                {
                    return true;
                }

                derivedType = derivedType.BaseType;
            }
            return false;
        }
    }
}
