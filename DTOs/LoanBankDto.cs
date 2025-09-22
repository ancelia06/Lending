using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanBankDto
    {
        public int BankId { get; set; }

        [Required(ErrorMessage = "Bank name is required.")]
        [StringLength(255)]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255)]
        public string Address { get; set; }

    }
}
