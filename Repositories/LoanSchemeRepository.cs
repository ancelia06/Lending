using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public class LoanSchemeRepository:ILoanSchemeRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanSchemeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoanScheme> GetByIdAsync(int id)
        {
            return await _context.LoanSchemes.FirstOrDefaultAsync(s => s.LoanSchemeId == id);
        }

        public async Task<IEnumerable<LoanScheme>> GetAllAsync()
        {
            return await _context.LoanSchemes.ToListAsync();
        }

        public async Task AddAsync(LoanScheme scheme)
        {
            await _context.LoanSchemes.AddAsync(scheme);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoanScheme scheme)
        {
            _context.LoanSchemes.Update(scheme);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var scheme = await GetByIdAsync(id);
            if (scheme != null)
            {
                _context.LoanSchemes.Remove(scheme);
                await _context.SaveChangesAsync();
            }
        }
    }
}
