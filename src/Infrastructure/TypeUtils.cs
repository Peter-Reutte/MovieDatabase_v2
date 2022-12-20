using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class TypeUtils
    {
        internal static List<Type> FindGenericInterfaces(Type handler, Type genericHandler)
        {
            var supportedTypes = handler
                .GetTypeInfo().ImplementedInterfaces
                .Where(iface =>
                {
                    var itype = iface.GetTypeInfo();
                    return itype.IsInterface && itype.IsGenericType && itype.GetGenericTypeDefinition() == genericHandler;
                })
                .Select(iface => iface.GenericTypeArguments[0])
                .ToList();

            return supportedTypes;
        }
    }
}
