using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class LoanSchemeRepository : ILoanSchemeRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanSchemeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLoanSchemeAsync(LoanScheme loanScheme)
        {
            await _context.LoanSchemes.AddAsync(loanScheme);
            await _context.SaveChangesAsync();
        }

        public async Task<LoanScheme> GetLoanSchemeByIdAsync(int id)
        {
            return await _context.LoanSchemes
                                 .Include(ls => ls.LoanBank)
                                 .FirstOrDefaultAsync(ls => ls.LoanSchemeId == id);
        }

        public async Task<IEnumerable<LoanScheme>> GetAllLoanSchemesAsync()
        {
            return await _context.LoanSchemes
                                 .Include(ls => ls.LoanBank)
                                 .ToListAsync();
        }

        public async Task<bool> UpdateLoanSchemeAsync(LoanScheme loanScheme)
        {
            _context.Entry(loanScheme).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanSchemeExists(loanScheme.LoanSchemeId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteLoanSchemeAsync(int id)
        {
            var loanScheme = await _context.LoanSchemes.FindAsync(id);
            if (loanScheme == null)
            {
                return false;
            }

            _context.LoanSchemes.Remove(loanScheme);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool LoanSchemeExists(int id)
        {
            return _context.LoanSchemes.Any(e => e.LoanSchemeId == id);
        }

    }
}
