using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class LoanOfficerRepository : ILoanOfficerRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanOfficerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLoanOfficerAsync(LoanOfficer loanOfficer)
        {
            await _context.LoanOfficers.AddAsync(loanOfficer);
            await _context.SaveChangesAsync();
        }

        public async Task<LoanOfficer> GetLoanOfficerByIdAsync(int id)
        {
            return await _context.LoanOfficers
                                 .Include(lo => lo.Branch)
                                 .Include(lo => lo.LoanBank)
                                 .FirstOrDefaultAsync(lo => lo.UserId == id);
        }

        public async Task<IEnumerable<LoanOfficer>> GetAllLoanOfficersAsync()
        {
            return await _context.LoanOfficers
                                 .Include(lo => lo.Branch)
                                 .Include(lo => lo.LoanBank)
                                 .Include(lo => lo.AssignedApplications)
                                 .ToListAsync();
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
                if (!LoanOfficerExists(loanOfficer.UserId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
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

        public async Task<LoanOfficer> GetAssignedOfficerByBranchId(int branchId)
        {
            // Find the officer in the specified branch with the least number of assigned applications.
            var officer = await _context.LoanOfficers
                                        .Include(lo => lo.AssignedApplications)
                                        .Where(lo => lo.BranchId == branchId)
                                        .OrderBy(lo => lo.AssignedApplications.Count)
                                        .FirstOrDefaultAsync();

            return officer;
        }

        private bool LoanOfficerExists(int id)
        {
            return _context.LoanOfficers.Any(e => e.UserId == id);
        }

    }
}
