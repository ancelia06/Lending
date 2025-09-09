using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class LoanScheme
    {
        [Key]
        public int SchemeId { get; set; }

        [Required]
        [StringLength(255)]
        public string SchemeName { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [Required]
        public int MinCreditScore { get; set; }

        public int CompanyId { get; set; }
        public LoanCompany LoanCompany { get; set; }
    }

}
