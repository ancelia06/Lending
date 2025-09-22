using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class LoanBankRepository:ILoanBankRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanBankRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBankAsync(LoanBank bank)
        {
            await _context.LoanBanks.AddAsync(bank);
            await _context.SaveChangesAsync();
        }

        public async Task<LoanBank> GetBankByIdAsync(int id)
        {
            return await _context.LoanBanks.FindAsync(id);
        }

        public async Task<IEnumerable<LoanBank>> GetAllBanksAsync()
        {
            return await _context.LoanBanks.ToListAsync();
        }

        public async Task<bool> UpdateBankAsync(LoanBank bank)
        {
            _context.Entry(bank).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(bank.BankId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteBankAsync(int id)
        {
            var bank = await _context.LoanBanks.FindAsync(id);
            if (bank == null)
            {
                return false;
            }

            _context.LoanBanks.Remove(bank);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool BankExists(int id)
        {
            return _context.LoanBanks.Any(e => e.BankId == id);
        }

    }
}
