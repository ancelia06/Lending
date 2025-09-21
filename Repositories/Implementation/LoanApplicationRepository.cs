using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class LoanApplicationRepository:ILoanApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLoanApplicationAsync(LoanApplication loanApplication)
        {
            await _context.LoanApplications.AddAsync(loanApplication);
            await _context.SaveChangesAsync();
        }

        public async Task<LoanApplication> GetLoanApplicationByIdAsync(int loanApplicationId)
        {
            return await _context.LoanApplications
                                 .Include(la => la.Customer)
                                 .Include(la => la.LoanScheme)
                                 .FirstOrDefaultAsync(la => la.LoanApplicationId == loanApplicationId);
        }

        public async Task<IEnumerable<LoanApplication>> GetLoanApplicationsByOfficerIdAsync(int officerId)
        {
            return await _context.LoanApplications
                                 .Include(la => la.Customer)
                                 .Include(la => la.LoanScheme)
                                 .Where(la => la.LoanOfficerId == officerId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<LoanApplication>> GetLoanApplicationsByCustomerIdAsync(int customerId)
        {
            return await _context.LoanApplications
                                 .Include(la => la.LoanScheme)
                                 .Where(la => la.CustomerId == customerId)
                                 .ToListAsync();
        }

        public async Task<bool> UpdateLoanApplicationStatusAsync(LoanApplication loanApplication)
        {
            _context.Entry(loanApplication).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanApplicationExists(loanApplication.LoanApplicationId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers.Include(c => c.Branch).FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        private bool LoanApplicationExists(int id)
        {
            return _context.LoanApplications.Any(e => e.LoanApplicationId == id);
        }


    }
}
