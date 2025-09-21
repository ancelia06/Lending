using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface ILoanBankRepository
    {
        Task AddBankAsync(LoanBank bank);
        Task<LoanBank> GetBankByIdAsync(int id);
        Task<IEnumerable<LoanBank>> GetAllBanksAsync();
        Task<bool> UpdateBankAsync(LoanBank bank);
        Task<bool> DeleteBankAsync(int id);
    }
}
