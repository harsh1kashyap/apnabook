using System.Reflection;
using ApnaBook.Application.Common.Interfaces;
using ApnaBook.Domain.Entities;
using ApnaBook.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectPilot.Application.Common.Models;

namespace ApnaBook.Infrastructure.Data;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Customers> Customers => Set<Customers>();
    public DbSet<Books> Books => Set<Books>();
    public DbSet<Categories> Categories => Set<Categories>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<Orders> Orders => Set<Orders>();
    public DbSet<OrderItems> OrderItems => Set<OrderItems>();
    public DbSet<Reviews> Reviews => Set<Reviews>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //To Change table names to SnakeCase
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Convert table names to snake_case
            var tableName = entity.GetTableName();
            if (tableName != null)
            {
                entity.SetTableName(tableName.ToSnakeCase());
            }

            // Convert property names to snake_case
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.Name.ToSnakeCase());
            }

            // Convert key names to snake_case
            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (keyName != null)
                {
                    key.SetName(keyName.ToSnakeCase());
                }
            }

            // Convert foreign key names to snake_case
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var constraintName = foreignKey.GetConstraintName();
                if (constraintName != null)
                {
                    foreignKey.SetConstraintName(constraintName.ToSnakeCase());
                }
            }

            // Convert index names to snake_case
            foreach (var index in entity.GetIndexes())
            {
                var indexName = index.GetDatabaseName();
                if (indexName != null)
                {
                    index.SetDatabaseName(indexName.ToSnakeCase());
                }
            }
        }

    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
