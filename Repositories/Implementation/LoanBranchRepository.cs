using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class LoanBranchRepository:ILoanBranchRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanBranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBranchAsync(LoanBranch branch)
        {
            await _context.LoanBranches.AddAsync(branch);
            await _context.SaveChangesAsync();
        }

        public async Task<LoanBranch> GetBranchByIdAsync(int id)
        {
            return await _context.LoanBranches
                                 .Include(b => b.LoanBank) // Include the navigation property
                                 .FirstOrDefaultAsync(b => b.BranchId == id);
        }

        public async Task<IEnumerable<LoanBranch>> GetAllBranchesAsync()
        {
            return await _context.LoanBranches
                                 .Include(b => b.LoanBank) // Include the navigation property
                                 .ToListAsync();
        }

        public async Task<bool> UpdateBranchAsync(LoanBranch branch)
        {
            _context.Entry(branch).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(branch.BranchId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteBranchAsync(int id)
        {
            var branch = await _context.LoanBranches.FindAsync(id);
            if (branch == null)
            {
                return false;
            }

            _context.LoanBranches.Remove(branch);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool BranchExists(int id)
        {
            return _context.LoanBranches.Any(e => e.BranchId == id);
        }

    }
}
