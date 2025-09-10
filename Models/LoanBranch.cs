namespace Lending_CapstoneProject.Models
{
    public class LoanBranch
    {
        public int BranchId { get; set; }
    public string Location { get; set; }
    public ICollection<LoanOfficer> Officers { get; set; }
    }
}

