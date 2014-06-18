namespace Core.Data.Mappings
{
    using System;

    internal static class MappingExtensions
    {
        internal static string GetIdColumnName(this Type type)
        {
            return type.Name + "Id";
        }
    }
}