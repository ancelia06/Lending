using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class RepaymentDto
    {
        [Required(ErrorMessage = "Due date is required.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Repayment method is required.")]
        public RepaymentMethod Method { get; set; }

        [Required(ErrorMessage = "Loan application ID is required.")]
        public int LoanApplicationId { get; set; }
    }
}
