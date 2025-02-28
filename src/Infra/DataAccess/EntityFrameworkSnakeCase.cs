using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.RegularExpressions;

namespace Infra.DataAccess
{
    public static class EntityFrameworkSnakeCase
    {
        public static void ApplySnakeCaseNames(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model
                         .GetEntityTypes())
            {
                entity.SetTableName(ConvertToSnakeCase(entity.GetTableName()!));

                foreach (IMutableProperty property in entity.GetProperties())
                {
                    property.SetColumnName(
                        ConvertToSnakeCase(property.GetColumnName()));
                }

                foreach (IMutableKey key in entity.GetKeys())
                {
                    key.SetName(ConvertToSnakeCase(key.GetName()));
                }

                foreach (IMutableForeignKey key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(
                        ConvertToSnakeCase(key.GetConstraintName()));
                }

                foreach (IMutableIndex index in entity.GetIndexes())
                {
                    index.SetDatabaseName(
                        ConvertToSnakeCase(index.GetDatabaseName()));
                }
            }
        }

        private static string ConvertToSnakeCase(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            return Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2")
                .ToLower();
        }
    }
}
