using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanApplicationDto
    {
        [Required]
        public LoanType LoanType { get; set; }

        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public RepaymentMethod RepaymentMethod { get; set; }

        [Required]
        public int LoanSchemeId { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}
