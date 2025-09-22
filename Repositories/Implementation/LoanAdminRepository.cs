using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lending_CapstoneProject.Repositories.Interface;


namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class LoanAdminRepository : ILoanAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanAdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // LoanAdmin-specific methods
        public async Task<LoanAdmin> GetLoanAdminByIdAsync(int id)
        {
            return await _context.LoanAdmins.FindAsync(id);
        }

        public async Task<LoanAdmin> GetLoanAdminByUsernameAsync(string username)
        {
            return await _context.LoanAdmins.FirstOrDefaultAsync(la => la.UserName == username);
        }

        public async Task<IEnumerable<LoanAdmin>> GetAllLoanAdminsAsync()
        {
            return await _context.LoanAdmins.ToListAsync();
        }

        public async Task AddLoanAdminAsync(LoanAdmin loanAdmin)
        {
            await _context.LoanAdmins.AddAsync(loanAdmin);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateLoanAdminAsync(LoanAdmin loanAdmin)
        {
            _context.Entry(loanAdmin).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanAdminExists(loanAdmin.UserId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteLoanAdminAsync(int id)
        {
            var loanAdmin = await _context.LoanAdmins.FindAsync(id);
            if (loanAdmin == null)
            {
                return false;
            }
            _context.LoanAdmins.Remove(loanAdmin);
            await _context.SaveChangesAsync();
            return true;
        }

        // Loan Officer management methods
        public async Task<IEnumerable<LoanOfficer>> GetAllLoanOfficersAsync()
        {
            return await _context.LoanOfficers.ToListAsync();
        }

        public async Task<LoanOfficer> GetLoanOfficerByIdAsync(int id)
        {
            return await _context.LoanOfficers.FindAsync(id);
        }

        public async Task AddLoanOfficerAsync(LoanOfficer loanOfficer)
        {
            await _context.LoanOfficers.AddAsync(loanOfficer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateLoanOfficerAsync(LoanOfficer loanOfficer)
        {
            _context.Entry(loanOfficer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return !LoanOfficerExists(loanOfficer.UserId);
            }
        }

        public async Task<bool> DeleteLoanOfficerAsync(int id)
        {
            var loanOfficer = await _context.LoanOfficers.FindAsync(id);
            if (loanOfficer == null)
            {
                return false;
            }
            _context.LoanOfficers.Remove(loanOfficer);
            await _context.SaveChangesAsync();
            return true;
        }

        // Loan Scheme management methods
        public async Task<IEnumerable<LoanScheme>> GetAllLoanSchemesAsync()
        {
            return await _context.LoanSchemes.ToListAsync();
        }

        public async Task<LoanScheme> GetLoanSchemeByIdAsync(int id)
        {
            return await _context.LoanSchemes.FindAsync(id);
        }

        public async Task AddLoanSchemeAsync(LoanScheme loanScheme)
        {
            await _context.LoanSchemes.AddAsync(loanScheme);
            await _context.SaveChangesAsync();
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
                return !LoanSchemeExists(loanScheme.LoanSchemeId);
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

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        private bool LoanAdminExists(int id)
        {
            return _context.LoanAdmins.Any(e => e.UserId == id);
        }

        private bool LoanOfficerExists(int id)
        {
            return _context.LoanOfficers.Any(e => e.UserId == id);
        }

        private bool LoanSchemeExists(int id)
        {
            return _context.LoanSchemes.Any(e => e.LoanSchemeId == id);
        }

    }
}
