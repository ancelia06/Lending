using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface ICustomerService
    {
        Task<Customer> RegisterCustomerAsync(CustomerRegistrationDto registrationDto);
        Task<CustomerDto> GetCustomerProfileAsync(int customerId);
        Task<bool> UpdateCustomerProfileAsync(int customerId, CustomerProfileDto profileDto);
        Task<bool> IsEmailInUse(string email);
        Task<bool> IsAadharIdInUse(string aadharId);
        Task<bool> IsPanIdInUse(string panId);
    }

}
