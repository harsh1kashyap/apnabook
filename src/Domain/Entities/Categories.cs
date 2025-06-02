namespace ApnaBook.Domain.Entities;
public class Categories : BaseAuditableEntity
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public List<Books> Books { get; set; } = new List<Books>();
}
