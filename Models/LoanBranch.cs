namespace Lending_CapstoneProject.Models
{
    public class LoanBranch
    {
        [Key]
    public int BranchId { get; set; }

    [Required]
    public string Location { get; set; }

    public ICollection<LoanOfficer> Officers { get; set; }
    }
}


