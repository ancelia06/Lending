using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves a user for login based on a provided username or email.
        public async Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.UserName == usernameOrEmail || u.Email == usernameOrEmail);
        }

        // Retrieves a user by their unique ID.
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        // Adds a new user record to the database.
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }



    }
}
