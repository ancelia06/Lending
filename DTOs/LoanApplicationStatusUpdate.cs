using Lending_CapstoneProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.DTOs
{
    public class LoanApplicationStatusUpdateDto
    {
        [Required(ErrorMessage = "Status is required.")]
        public ApplicationStatus Status { get; set; }

        [StringLength(500, ErrorMessage = "Remarks cannot exceed 500 characters.")]
        public string Remarks { get; set; }

        public int LoanOfficerId { get; set; }
    }
}
