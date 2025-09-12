using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public class RepaymentRepository:IRepaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public RepaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Repayment> GetByIdAsync(int id)
        {
            return await _context.Repayments.FirstOrDefaultAsync(r => r.RepaymentId == id);
        }

        public async Task<IEnumerable<Repayment>> GetByLoanApplicationIdAsync(int loanApplicationId)
        {
            return await _context.Repayments
                .Where(r => r.LoanApplicationId == loanApplicationId)
                .OrderBy(r => r.PaymentDate) // Order by payment date to show history chronologically
                .ToListAsync();
        }

        public async Task AddAsync(Repayment repayment)
        {
            await _context.Repayments.AddAsync(repayment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Repayment repayment)
        {
            _context.Repayments.Update(repayment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repayment = await GetByIdAsync(id);
            if (repayment != null)
            {
                _context.Repayments.Remove(repayment);
                await _context.SaveChangesAsync();
            }
        }


    }
}
