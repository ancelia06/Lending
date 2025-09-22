using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lending_CapstoneProject.Models
{
    public class Repayment
    {
        [Key]
        public int RepaymentId { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        // New fields to store the segregated principal and interest amounts
        [Required]
        public decimal PrincipalPaid { get; set; }

        [Required]
        public decimal InterestPaid { get; set; }

        // Changed from Required. It's null until payment is made.
        public DateTime? PaymentDate { get; set; }

        [Required]
        public RepaymentMethod Method { get; set; }

        [Required]
        public RepaymentStatus Status { get; set; } = RepaymentStatus.Pending;

        [StringLength(255)]
        public string TransactionId { get; set; }

        // Foreign Key
        public int LoanApplicationId { get; set; }
        // Navigation Property
        public LoanApplication LoanApplication { get; set; }


    }
}
