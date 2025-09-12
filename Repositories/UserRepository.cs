using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            // Use Include to load derived types (e.g., Customer, LoanOfficer)
            return await _context.Users
                .Include(u => (u as Customer))
                .Include(u => (u as LoanOfficer))
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> GetByLoginCredentialAsync(string identifier)
        {
            // This method handles the flexible login scenario, checking for PanId, Email, or UserName.
            // Note: PanId is a property of the Customer model, which inherits from User.
            // The query needs to specifically check the Customer table.

            // 1. Check if the identifier is a PanId (10 characters, alphanumeric)
            if (identifier.Length == 10)
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.PanId == identifier);
                if (customer != null)
                {
                    return customer;
                }
            }

            // 2. Assume the identifier is either an Email or a UserName and query the base User table
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == identifier || u.UserName == identifier);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}
