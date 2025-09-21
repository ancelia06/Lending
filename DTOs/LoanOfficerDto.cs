using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanOfficerDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        [StringLength(50, ErrorMessage = "Employee ID cannot exceed 50 characters.")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Branch ID is required.")]
        public int BranchId { get; set; }

        public string BranchLocation { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int AssignedApplicationsCount { get; set; }

    }
}
