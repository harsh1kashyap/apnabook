

using System.ComponentModel.DataAnnotations;

namespace ApnaBook.Domain.Entities;
public class Reviews:BaseAuditableEntity
{
    public int CustomerId { get; set; }
    public int BookId { get; set; }
    public int Rating { get; set; }
    [MaxLength(1000)]
    public string Comment { get; set; } = string.Empty;
    public Customers Customers { get; set; } = new Customers();
    public Books Books { get; set; } = new Books();
}
