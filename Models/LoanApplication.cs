using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lending_CapstoneProject.Models
{
    public class LoanApplication
    {
        [Key]
        public int LoanApplicationId { get; set; }

        [Required]
        public LoanType LoanType { get; set; }

        [Required]
        [Range(1000, double.MaxValue, ErrorMessage = "Loan amount must be at least ₹1000.")]
        public decimal LoanAmount { get; set; }

        [Required]
        public ApplicationStatus ApplicationStatus { get; set; }
        [Required]
        public decimal RemainingBalance { get; set; }


        [Required]
        public RepaymentMethod RepaymentMethod { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        public DateTime StatusUpdatedDate { get; set; }

        [StringLength(1000)]
        public string Remarks { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; }

        // Foreign Keys and Navigation Properties

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("LoanOfficer")]
        public int LoanOfficerId { get; set; }
        public LoanOfficer LoanOfficer { get; set; }

        [ForeignKey("LoanScheme")]
        public int LoanSchemeId { get; set; }
        public LoanScheme LoanScheme { get; set; }

        public virtual ICollection<Repayment> Repayments { get; set; }
    }
}

