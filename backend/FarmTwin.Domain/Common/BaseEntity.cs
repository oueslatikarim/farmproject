namespace FarmTwin.Domain.Common;

public abstract class BaseEntity : IAuditableEntity, ISoftDelete
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // IAuditableEntity
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    // ISoftDelete
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
