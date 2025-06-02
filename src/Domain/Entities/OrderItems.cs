

using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaBook.Domain.Entities;
public class OrderItems:BaseAuditableEntity
{
    [ForeignKey("Orders")]
    public int OrderId { get; set; }
    [ForeignKey("Books")]
    public int BookId { get; set; }
    public int Quantity { get; set; }
    public int SubTotal { get; set; }
    public Books Books { get; set; } = new Books();
    public Orders Orders { get; set; } = new Orders();

}
