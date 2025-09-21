using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface ILoanSchemeRepository
    {

        // FR1.1: CRUD operations for Loan Schemes
        Task AddLoanSchemeAsync(LoanScheme loanScheme);
        Task<LoanScheme> GetLoanSchemeByIdAsync(int id);
        Task<IEnumerable<LoanScheme>> GetAllLoanSchemesAsync();
        Task<bool> UpdateLoanSchemeAsync(LoanScheme loanScheme);
        Task<bool> DeleteLoanSchemeAsync(int id);

    }
}
