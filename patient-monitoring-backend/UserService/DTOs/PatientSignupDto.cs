using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class PatientSignupDto
    {
        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = null!;

        [Required, MaxLength(20)]
        public string Phone { get; set; } = null!;

        [Required, MinLength(6)]
        public string Password { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}