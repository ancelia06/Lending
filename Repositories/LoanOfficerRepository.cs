using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public class LoanOfficerRepository:ILoanOfficerRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanOfficerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoanOfficer> GetByIdAsync(int id)
        {
            return await _context.LoanOfficers
                .FirstOrDefaultAsync(o => o.UserId == id);
        }

        public async Task<IEnumerable<LoanOfficer>> GetAllOfficersAsync()
        {
            return await _context.LoanOfficers.ToListAsync();
        }

        public async Task AddAsync(LoanOfficer officer)
        {
            await _context.LoanOfficers.AddAsync(officer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoanOfficer officer)
        {
            _context.LoanOfficers.Update(officer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var officer = await GetByIdAsync(id);
            if (officer != null)
            {
                _context.LoanOfficers.Remove(officer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
