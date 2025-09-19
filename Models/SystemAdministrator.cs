using System.ComponentModel.DataAnnotations;

namespace Lending_CapstoneProject.Models
{
    public class SystemAdministrator : User
    {
        [Required]
        public string Name { get; set; }
    }   
}
