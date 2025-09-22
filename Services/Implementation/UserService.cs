using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> RegisterUserAsync<T>(T registrationDto, UserType userType)
        {
            // Check if user already exists based on email or username from the DTO.
            dynamic dto = registrationDto;
            var existingUser = await _userRepository.GetUserByUsernameOrEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return false; // User with this email already exists
            }

            // Map the DTO to the appropriate user model based on UserType
            User newUser;
            switch (userType)
            {
                case UserType.Customer:
                    newUser = _mapper.Map<Customer>(registrationDto);
                    break;
                case UserType.LoanOfficer:
                    // Assuming you have a LoanOfficerRegistrationDto
                    // newUser = _mapper.Map<LoanOfficer>(registrationDto);
                    // For now, let's throw an exception or handle a default case
                    throw new NotImplementedException("Loan Officer registration not implemented.");
                case UserType.LoanAdmin:
                    // Assuming you have a LoanAdminRegistrationDto
                    // newUser = _mapper.Map<LoanAdmin>(registrationDto);
                    throw new NotImplementedException("Loan Admin registration not implemented.");
                default:
                    return false;
            }

            // Set common user properties
            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            newUser.UserType = userType;

            // Add the new user to the database
            await _userRepository.AddUserAsync(newUser);
            return true;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            // Find the user by either username or email as per LoginDto logic
            var user = await _userRepository.GetUserByUsernameOrEmailAsync(loginDto.UserName ?? loginDto.Email);
            if (user == null)
            {
                return null; // User not found
            }

            // Verify the password hash
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return null; // Incorrect password
            }

            // In a real application, you would generate a JWT token here
            // This is a placeholder for the login success scenario
            return "Login Successful";
        }

    }
}
