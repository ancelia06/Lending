using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoginDto
    {
        [StringLength(10, MinimumLength = 10, ErrorMessage = "PAN ID must be exactly 10 characters.")]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "PAN ID must be in the format ABCDE1234F.")]
        public string PanId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters.")]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserType UserType { get; set; }

    }
}
