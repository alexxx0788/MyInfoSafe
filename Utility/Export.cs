using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility.Attributes;

namespace Utility
{
    public static class Exporter
    {
        public static IEnumerable<string> ToCsv<T>(IEnumerable<T> objectlist, string separator = ",", bool header = true)
        {
            var properties = GetPropertiesForSerialize(typeof (T));
            if (header)
            {
                yield return string.Join(separator, properties.Select(p => p.Name).ToArray());
            }
            foreach (var o in objectlist)
            {
                yield return string.Join(separator,properties.Select(p => (p.GetValue(o, null) ?? string.Empty).ToString()).ToArray());
            }
        }

        private static PropertyInfo[] GetPropertiesForSerialize(Type type)
        {
            var properties =
                type.GetProperties().Where(p => p.CustomAttributes.All(a => a.AttributeType != typeof (NotSerializedAttribute))).ToArray();
            return properties;
        } 
    }
}
