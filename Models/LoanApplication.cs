using Lending_CapstoneProject.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class LoanApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public LoanType LoanType { get; set; }

        [Required]
        public double LoanAmount { get; set; }

        [Required]
        public ApplicationStatus ApplicationStatus { get; set; }

        [Required]
        public RepaymentMethod RepaymentMethod { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int LoanOfficerId { get; set; }

        [Required]
        public int LoanSchemeId { get; set; }

        public Customer Customer { get; set; }
        public LoanOfficer LoanOfficer { get; set; }
        public LoanScheme LoanScheme { get; set; }
        public ICollection<Repayment> Repayments { get; set; }
    }

}
