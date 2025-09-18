using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public abstract class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }


        [Required]
        public UserType UserType { get; set; }

        // Optional: each user may belong to a loan company
        public int? LoanBankId { get; set; }
        public LoanBank LoanBank{ get; set; }
    }
}
