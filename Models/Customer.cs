using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class Customer : User
    {
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhar ID must be exactly 12 digits.")]
        public string AadharId { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "PAN ID must be exactly 10 characters.")]
        public string PanId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int BranchId { get; set; }
        public LoanBranch Branch { get; set; }
        public string City { get; set; } // For auto-assignment feature
        public ICollection<LoanApplication> LoanApplications { get; set; }
    }
}
