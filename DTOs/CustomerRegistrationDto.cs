using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class CustomerRegistrationDto
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(15, ErrorMessage = "Contact number cannot exceed 15 characters.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Aadhar ID is required.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhar ID must be exactly 12 digits.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar ID must contain only digits.")]
        public string AadharId { get; set; }

        [Required(ErrorMessage = "PAN ID is required.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "PAN ID must be exactly 10 characters.")]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "PAN ID must be in the format ABCDE1234F.")]
        public string PanId { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public int? BranchId { get; set; }
        public string City { get; set; }

    }
}
