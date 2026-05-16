using FarmTwin.Domain.Common;

namespace FarmTwin.Domain.Entities.Identity;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

    public DateTime? RevokedAt { get; set; }
    public string? ReplacedByToken { get; set; }
    public bool IsActive => RevokedAt == null && !IsExpired;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
