using ApnaBook.Domain.Entities;

namespace ApnaBook.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Customers> Customers { get; }
    DbSet<Categories> Categories { get; }
    DbSet<Books> Books { get; }
    DbSet<Cart> Carts { get; }
    DbSet<Orders> Orders { get; }
    DbSet<OrderItems> OrderItems { get; }
    DbSet<Reviews> Reviews { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
