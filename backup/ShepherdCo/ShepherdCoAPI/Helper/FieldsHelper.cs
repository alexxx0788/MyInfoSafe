using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ShepherdCoAPI.Shared.Attributes;

namespace ShepherdCoAPI.Helper
{
    public static class FieldsHelper
    {
        public static string GetSearchByField(Type type)
        {
            PropertyInfo field = type?.GetProperties().FirstOrDefault(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(SearchByAttribute)));
            if (field != null) return field.Name;
            return string.Empty;
        }

        public static string GetDeleteByField(Type type)
        {
            PropertyInfo field = type?.GetProperties().FirstOrDefault(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(DeleteAttribute)));
            if (field != null) return field.Name;
            return string.Empty;
        }

        public static string GetFieldsForInsert(Type type, string separator)
        {
            if (type != null)
            {
                var fields = type.GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(UpdateAttribute))).ToArray();
                return string.Join(separator, fields.Select(x => x.Name));
            }
            return string.Empty;
        }
        public static string GetFieldsForUpdate(Type type)
        {
            if (type != null)
            {
                var fields = type.GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(UpdateAttribute))).Select(x => $"[{x.Name}]=@{x.Name}");
                return string.Join(",", fields.Select(x => x));
            }
            return string.Empty;
        }
    }
}
