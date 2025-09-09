using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class Customer : User
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<LoanApplication> LoanApplications { get; set; }
    }

}
