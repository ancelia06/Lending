using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class RepaymentRepository : IRepaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public RepaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRepaymentAsync(Repayment repayment)
        {
            await _context.Repayments.AddAsync(repayment);
            await _context.SaveChangesAsync();
        }

        public async Task<Repayment> GetRepaymentByIdAsync(int id)
        {
            return await _context.Repayments
                                 .Include(r => r.LoanApplication)
                                 .FirstOrDefaultAsync(r => r.RepaymentId == id);
        }

        public async Task<IEnumerable<Repayment>> GetRepaymentsByLoanApplicationIdAsync(int loanApplicationId)
        {
            return await _context.Repayments
                                 .Where(r => r.LoanApplicationId == loanApplicationId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Repayment>> GetRepaymentHistoryForCustomerAsync(int customerId)
        {
            return await _context.Repayments
                                 .Include(r => r.LoanApplication)
                                 .Where(r => r.LoanApplication.CustomerId == customerId)
                                 .OrderBy(r => r.DueDate)
                                 .ToListAsync();
        }

        public async Task<bool> UpdateRepaymentAsync(Repayment repayment)
        {
            _context.Entry(repayment).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepaymentExists(repayment.RepaymentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteRepaymentAsync(int id)
        {
            var repayment = await _context.Repayments.FindAsync(id);
            if (repayment == null)
            {
                return false;
            }

            _context.Repayments.Remove(repayment);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool RepaymentExists(int id)
        {
            return _context.Repayments.Any(e => e.RepaymentId == id);
        }
        // Added to support the EmailService
        public async Task<IEnumerable<Repayment>> GetAllRepaymentsAsync()
        {
            return await _context.Repayments
                                 .Include(r => r.LoanApplication)
                                     .ThenInclude(la => la.Customer)
                                 .ToListAsync();
        }



    }
}

