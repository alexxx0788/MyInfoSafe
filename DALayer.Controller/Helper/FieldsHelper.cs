using System;
using System.Linq;
using System.Reflection;
using DALayer.Controller.Model.Attributes;

namespace DALayer.Controller.Helper
{
    public static class FieldsHelper
    {
        public static string GetFieldForSearch(Type type)
        {
            if (type != null)
            {
                PropertyInfo field = type.GetProperties().FirstOrDefault(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(SearchableAttribute)));
                if (field != null) return field.Name;
            }
            return string.Empty;
        }
        public static string GetFieldForSelect(Type type)
        {
            if (type != null)
            {
                PropertyInfo field = type.GetProperties().FirstOrDefault(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(SelectebleAttribute)));
                if (field != null) return field.Name;
            }
            return string.Empty;
        }

        public static string GetFieldForRemove(Type type)
        {
            if (type != null)
            {
                PropertyInfo field = type.GetProperties().FirstOrDefault(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(RemovableAttribute)));
                if (field != null) return field.Name;
            }
            return string.Empty;
        }

        public static string GetFieldsForInsert(Type type, string separator)
        {
            if (type != null)
            {
                var fields = type.GetProperties().Where(x => x.CustomAttributes.Any(y=>y.AttributeType == typeof(ChangeableAttribute))).ToArray();
                return string.Join(separator, fields.Select(x => x.Name));
            }
            return string.Empty;
        }
        public static string GetFieldsForUpdate(Type type)
        {
            if (type != null)
            {
                var fields = type.GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(ChangeableAttribute))).Select(x=>$"[{x.Name}]=@{x.Name}");
                return string.Join(",", fields.Select(x => x));
            }
            return string.Empty;
        }
    }
}
