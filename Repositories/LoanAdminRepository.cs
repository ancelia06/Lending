using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public class LoanAdminRepository:ILoanAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanAdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoanAdmin> GetByIdAsync(int id)
        {
            return await _context.LoanAdmins
                .FirstOrDefaultAsync(a => a.UserId == id);
        }

        public async Task<IEnumerable<LoanAdmin>> GetAllAdminsAsync()
        {
            return await _context.LoanAdmins.ToListAsync();
        }

        public async Task AddAsync(LoanAdmin admin)
        {
            await _context.LoanAdmins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoanAdmin admin)
        {
            _context.LoanAdmins.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var admin = await GetByIdAsync(id);
            if (admin != null)
            {
                _context.LoanAdmins.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }
    }
}
