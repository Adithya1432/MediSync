using System.ComponentModel.DataAnnotations;
using UserService.Models;

namespace UserService.Models
{
    public class UserAudit
    {
        [Key]
        public Guid AuditId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Action { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string PerformedBy { get; set; } = null!;

        [Required]
        public DateTime Timestamp { get; set; }

        [MaxLength(100)]
        public string? Remarks { get; set; }
        public User User { get; set; } = null!;
    }
}