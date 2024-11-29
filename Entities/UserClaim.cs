using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTCApp.Entities
{
    [Table("UserClaim", Schema = "Security")]
    public class UserClaim
    {
        [Key]
        public Guid ClaimId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClaimType { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClaimValue { get; set; }
    }
}
