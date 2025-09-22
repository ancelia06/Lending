using Lending_CapstoneProject.DTOs;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface ILoanBankService
    {
        Task<LoanBankDto> AddBankAsync(LoanBankDto bankDto);
        Task<IEnumerable<LoanBankDto>> GetAllBanksAsync();
        Task<LoanBankDto> GetBankByIdAsync(int id);
        Task<bool> UpdateBankAsync(LoanBankDto bankDto);
        Task<bool> DeleteBankAsync(int id);

    }
}
