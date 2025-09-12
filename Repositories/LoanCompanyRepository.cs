using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public class LoanCompanyRepository:ILoanCompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanCompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoanCompany> GetAsync()
        {
            return await _context.LoanCompanies.FirstOrDefaultAsync();
        }

        public async Task AddAsync(LoanCompany company)
        {
            await _context.LoanCompanies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoanCompany company)
        {
            _context.LoanCompanies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetAsync();
            if (company != null)
            {
                _context.LoanCompanies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }


    }
}
