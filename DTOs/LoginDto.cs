using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoginDto
    {
        [StringLength(10, MinimumLength = 10)]
        public string PanId { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
