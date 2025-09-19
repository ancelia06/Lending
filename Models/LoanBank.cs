using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class LoanBank
    {
        [Key]
        public int BankId { get; set; }

        [StringLength(255)]
        public string BankName { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        // Navigation properties
        public ICollection<LoanScheme> LoanSchemes { get; set; }
        public ICollection<LoanOfficer> LoanOfficers { get; set; }
        public ICollection<LoanBranch> LoanBranches { get; set; }
        // Change the f ile yo Bank
        public ICollection<User> Users { get; set; }

    }
}
