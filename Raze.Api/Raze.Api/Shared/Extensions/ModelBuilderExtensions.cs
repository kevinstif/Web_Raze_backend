using Microsoft.EntityFrameworkCore;

namespace Raze.Api.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void UseSnakeCaseNamingConventions(this ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());

                foreach (var key in entity.GetKeys()) key.SetName(key.GetName().ToSnakeCase());

                foreach (var foreingKey in entity.GetForeignKeys())
                    foreingKey.SetConstraintName(foreingKey.GetConstraintName().ToSnakeCase());

                foreach (var index in entity.GetIndexes()) index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}