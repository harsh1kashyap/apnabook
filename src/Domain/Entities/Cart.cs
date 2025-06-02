
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaBook.Domain.Entities;
public class Cart:BaseAuditableEntity
{
    [ForeignKey("Customers")]
    public int CustomerId { get; set; }
    public Customers Customers { get; set; } = new Customers();
    [ForeignKey("Books")]
    public int BookId { get; set; }
    public Books Books { get; set; } = new Books();
    [Required]
    public int Quantity { get; set; }
}
