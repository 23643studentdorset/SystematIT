using System.ComponentModel.DataAnnotations;

namespace Infrastucture.Identity.DTOs
{
    public class AuthRequest
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}
