

using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaBook.Domain.Entities;
public class Books : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string StockQuantity { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [ForeignKey("Categories")]
    public int CategoryId { get; set; }
    public Categories Categories { get; set; } = new Categories();
    public List<Cart> CartItems { get; set; } = new List<Cart>();
    public List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    public List<Reviews> Reviews { get; set; } = new List<Reviews>();
}
