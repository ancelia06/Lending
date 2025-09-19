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

        // Changed from Required. It's null until payment is made.
        public DateTime? PaymentDate { get; set; }

        [Required]
        public RepaymentMethod Method { get; set; }

        // This should likely have a default value of 'Pending' set in the database.
        [Required]
        public RepaymentStatus Status { get; set; } = RepaymentStatus.Pending;

        // Foreign Key
        public int LoanApplicationId { get; set; }
        // Navigation Property
        public LoanApplication LoanApplication { get; set; }


    }
}
