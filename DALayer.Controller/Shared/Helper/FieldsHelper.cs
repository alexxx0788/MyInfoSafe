using System;
using System.Linq;
using System.Reflection;
using IStor.DAL.Shared.Attributes;
using IStorage.DAL.Model;

namespace IStorage.DAL.Shared.Helper
{
    public static class FieldsHelper
    {
        // Get field marked as PrimaryKey
        public static string GetPrimaryKey(Type type)
        {
            PropertyInfo field = type?.GetProperties().FirstOrDefault(x => x.CustomAttributes.Any(y => IsFieldPrimaryKey(y.AttributeType)));
            if (field != null) return field.Name;
            return string.Empty;
        }

        // Get all fields not marked as PrimaryKey for Insert statement
        public static string GetFieldsForInsert(Type type, string separator)
        {
            if (type != null)
            {
                var fields = type.GetProperties().Where(x =>
                !IsTypeDto(x.PropertyType) &&
                !x.CustomAttributes.Any(y => IsFieldPrimaryKey(y.AttributeType) || IsReadOnly(y.AttributeType))
                ).ToArray();
                return string.Join(separator, fields.Select(x => x.Name));
            }
            return string.Empty;
        }

        // Get all fields not marked as PrimaryKey for Insert Update
        public static string GetFieldsForUpdate(Type type)
        {
            if (type != null)
            {
                var fields = type.GetProperties().Where(x =>
                !IsTypeDto(x.PropertyType) &&
                !x.CustomAttributes.Any(y => IsFieldPrimaryKey(y.AttributeType) || IsReadOnly(y.AttributeType))
                ).Select(x => $"[{x.Name}]=@{x.Name}");
                return string.Join(",", fields.Select(x => x));
            }
            return string.Empty;
        }

        private static bool IsFieldPrimaryKey(Type type)
        {
            return type == typeof(PrimaryKeyAttribute);
        }
        private static bool IsReadOnly(Type type)
        {
            return type == typeof(ReadOnlyAttribute);
        }
        private static bool IsTypeDto(Type type)
        {
            return typeof(IDto).IsAssignableFrom(type);
        }

    }
}
