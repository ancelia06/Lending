using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanApplicationStatusUpdateDto
    {
        [Required]
        public ApplicationStatus Status { get; set; }
    }

}
