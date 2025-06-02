

using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaBook.Domain.Entities;
public class Orders:BaseAuditableEntity
{
    [ForeignKey("Customers")]
    public int CustomerId { get; set; }
    public Customers Customers { get; set; } = new Customers();
    public double TotalAmount { get; set; }
    public int Status { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

}
