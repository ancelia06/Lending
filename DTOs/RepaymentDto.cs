using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class RepaymentDto
    {
        public int RepaymentId { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, 1000000, ErrorMessage = "Amount must be between ₹1 and ₹10,00,000.")]
        public decimal Amount { get; set; }

        // These fields are new and will be used to display the segregated amounts to the user.
        public decimal PrincipalPaid { get; set; }
        public decimal InterestPaid { get; set; }

        [Required(ErrorMessage = "Repayment method is required.")]
        public RepaymentMethod Method { get; set; }

        public RepaymentStatus Status { get; set; } = RepaymentStatus.Pending;

        public DateTime? PaymentDate { get; set; }

        [Required(ErrorMessage = "Loan application ID is required.")]
        public int LoanApplicationId { get; set; }

        public string TransactionId { get; set; }
        public string CustomerName { get; set; }
        public decimal LoanAmount { get; set; }
        public int InstallmentNumber { get; set; }


    }
}
