using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        /// <summary>
        /// Authenticates a user by checking their login credential (PanId, Email, or UserName).
        /// </summary>
        /// <param name="identifier">The user's login credential (PanId, Email, or UserName).</param>
        /// <returns>A User object if a match is found, otherwise null.</returns>
        Task<User> GetByLoginCredentialAsync(string identifier);

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The User object to add.</param>
        Task AddAsync(User user);

        /// <summary>
        /// Updates an existing user's information in the database.
        /// </summary>
        /// <param name="user">The updated User object.</param>
        Task UpdateAsync(User user);

        /// <summary>
        /// Deletes a user from the database by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the user to delete.</param>
        Task DeleteAsync(int id);







    }
}
