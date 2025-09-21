using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface IUserRepository
    {
        // Get a user by their username or email for authentication purposes.
        Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail);

        // Get a user by their ID
        Task<User> GetUserByIdAsync(int userId);

        // Add a new user to the system.
        Task AddUserAsync(User user);

    }
}
