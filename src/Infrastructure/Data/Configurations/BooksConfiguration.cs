

using ApnaBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApnaBook.Infrastructure.Data.Configurations;
public class BooksConfiguration : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder
            .HasOne(b => b.Categories)
            .WithMany(c => c.Books)
            .HasPrincipalKey(c => c.CategoryId)
            .HasForeignKey(b => b.CategoryId);
    }
}
