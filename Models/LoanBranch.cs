using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class LoanBranch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        public string Location { get; set; }
        public int BankId { get; set; }
        public LoanBank LoanBank { get; set; }


        public ICollection<LoanOfficer> Officers { get; set; }
        //Add Customer
        public ICollection<Customer> Customers { get; set; }

    }
}
