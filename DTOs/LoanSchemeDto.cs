using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanSchemeDto
    {
        [Required]
        public string SchemeName { get; set; }

        [Required]
        public double InterestRate { get; set; }

        [Required]
        public int MinCreditScore { get; set; }
    }

}
