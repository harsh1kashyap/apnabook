namespace ApnaBook.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTimeOffset DeletedOn { get; set; }

    public string? DeletedBy { get; set; }
}
