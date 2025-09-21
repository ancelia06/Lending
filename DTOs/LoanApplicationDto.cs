using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanApplicationDto
    {
        public int LoanApplicationId { get; set; }

        [Required(ErrorMessage = "Loan type is required.")]
        public LoanType LoanType { get; set; }

        [Required(ErrorMessage = "Loan amount is required.")]
        [Range(1000, 100000000, ErrorMessage = "Loan amount must be between ₹1000 and ₹10,00,00,000.")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "Repayment method is required.")]
        public RepaymentMethod RepaymentMethod { get; set; }

        [Required(ErrorMessage = "Loan scheme ID is required.")]
        public int LoanSchemeId { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }

        public string SchemeName { get; set; }
        public decimal InterestRate { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string CustomerName { get; set; }
    }
}
