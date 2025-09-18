using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class LoanOfficer : User
    {
        [StringLength(50)]
        public string EmployeeId { get; set; }

        //public string BranchLocation { get; set; }

        public ICollection<LoanApplication> AssignedApplications { get; set; }

    }
}
