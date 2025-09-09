using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class LoanScheme
    {
        [Key]
        public int SchemeId { get; set; }

        [Required]
        public string SchemeName { get; set; }

        [Required]
        public double InterestRate { get; set; }

        [Required]
        public int MinCreditScore { get; set; }
    }

}
