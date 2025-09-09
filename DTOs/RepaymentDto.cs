using Lending_CapstoneProject.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class RepaymentDto
    {
        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public RepaymentMethod Method { get; set; }

        [Required]
        public int LoanApplicationId { get; set; }
    }

}
