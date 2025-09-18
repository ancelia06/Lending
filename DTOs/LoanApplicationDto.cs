using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanApplicationDto
    {
        [Required(ErrorMessage = "Loan type is required.")]
        public LoanType LoanType { get; set; }

        [Required(ErrorMessage = "Loan amount is required.")]
        [Range(1000, double.MaxValue, ErrorMessage = "Loan amount must be at least ₹1000.")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "Repayment method is required.")]
        public RepaymentMethod RepaymentMethod { get; set; }

        [Required(ErrorMessage = "Loan scheme ID is required.")]
        public int LoanSchemeId { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }
    }
}
