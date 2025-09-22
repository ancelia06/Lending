using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User type is required.")]
        public UserType UserType { get; set; }

        public int? LoanBankId { get; set; }
        public string BankName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }


    }
}
