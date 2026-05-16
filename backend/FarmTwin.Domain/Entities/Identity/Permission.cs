using FarmTwin.Domain.Common;

namespace FarmTwin.Domain.Entities.Identity;

public class Permission : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string SystemName { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
