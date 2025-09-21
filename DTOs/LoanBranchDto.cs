using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanBranchDto
    {
        public int BranchId { get; set; }


        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Bank ID is required.")]
        public int BankId { get; set; }
    }
}
