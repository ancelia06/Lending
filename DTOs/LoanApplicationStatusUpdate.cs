using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanApplicationStatusUpdateDto
    {
        [Required(ErrorMessage = "Status is required.")]
        public ApplicationStatus Status { get; set; }
    }
}
