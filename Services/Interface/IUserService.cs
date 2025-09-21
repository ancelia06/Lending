using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface IUserService
    {
        // A generic registration method that can handle different DTOs and user types.
        Task<bool> RegisterUserAsync<T>(T registrationDto, UserType userType);

        // A single login method for all user types.
        Task<string> LoginAsync(LoginDto loginDto);


    }

}
