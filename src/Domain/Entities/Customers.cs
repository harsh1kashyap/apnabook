using System.ComponentModel.DataAnnotations;

namespace ApnaBook.Domain.Entities;
public class Customers:BaseAuditableEntity
{
    [MaxLength(100)]
    public string CustomerName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string CustomerEmail { get; set; } = string.Empty;
    [MaxLength(20)]
    public string CustomerPhone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public int Role {  get; set; }
    public List<Cart> CartItems { get; set; } = new List<Cart>();
    public List<Orders> Orders { get; set; } = new List<Orders>();
    public List<Reviews> Reviews { get; set; } = new List<Reviews>();
}
