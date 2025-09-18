using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanSchemeDto
    {
        [Required(ErrorMessage = "Scheme name is required.")]
        public string SchemeName { get; set; }

        [Required(ErrorMessage = "Interest rate is required.")]
        public decimal InterestRate { get; set; }

        [Required(ErrorMessage = "Minimum credit score is required.")]
        public int MinCreditScore { get; set; }
    }
}
