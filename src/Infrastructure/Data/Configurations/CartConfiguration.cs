

using ApnaBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApnaBook.Infrastructure.Data.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasOne(x => x.Customers)
            .WithMany(c => c.CartItems)
            .HasForeignKey(c => c.CustomerId);

        builder.HasOne(c => c.Books)
            .WithMany(b => b.CartItems)
            .HasForeignKey(c => c.BookId);
    }
}
