using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class LoanOfficer : User
    {
        [StringLength(50)]
        public string EmployeeId { get; set; }
        public int BranchId { get; set; }
        public LoanBranch Branch { get; set; }
        public string AssignedCity { get; set; }


        public ICollection<LoanApplication> AssignedApplications { get; set; }

    }
}
