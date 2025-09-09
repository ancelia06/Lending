using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class LoanOfficer : User
    {
        [Key]
        public int OfficerId { get; set; }

        [Required]
        public string BranchName { get; set; }

        public ICollection<LoanApplication> AssignedApplications { get; set; }
    }

}
