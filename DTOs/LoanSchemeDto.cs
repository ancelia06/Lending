using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanSchemeDto
    {
        public int LoanSchemeId { get; set; }

        [Required(ErrorMessage = "Scheme name is required.")]
        [StringLength(255, ErrorMessage = "Scheme name cannot exceed 255 characters.")]
        public string SchemeName { get; set; }

        [Required(ErrorMessage = "Interest rate is required.")]
        [Range(0.1, 30.0, ErrorMessage = "Interest rate must be between 0.1% and 30%.")]
        public decimal InterestRate { get; set; }

        [Required(ErrorMessage = "Minimum credit score is required.")]
        [Range(300, 900, ErrorMessage = "Credit score must be between 300 and 900.")]
        public int MinCreditScore { get; set; }

        [Required]
        public int MinAmount { get; set; }

        [Required]
        public int MaxAmount { get; set; }

        [Required]
        public int DurationInMonths { get; set; }

        // BankId is required to link the scheme to an existing bank in the database.
        [Required]
        public int BankId { get; set; }

        // BankName is a display-only field and should not be required.
        public string BankName { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
