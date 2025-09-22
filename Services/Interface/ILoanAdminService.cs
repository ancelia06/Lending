using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface ILoanAdminService
    {
        // Login functionality
        Task<LoanAdmin> LoginAsync(LoginDto loginDto);

        // Management of Loan Officers (FR1.2)
        Task<IEnumerable<LoanOfficerDto>> GetAllLoanOfficersAsync();
        Task<LoanOfficer> AddLoanOfficerAsync(LoanOfficerDto loanOfficerDto);
        Task<bool> UpdateLoanOfficerAsync(int id, LoanOfficerDto loanOfficerDto);
        Task<bool> DeleteLoanOfficerAsync(int id);

        // Management of Loan Schemes (FR1.1)
        Task<IEnumerable<LoanSchemeDto>> GetAllLoanSchemesAsync();
        Task<LoanScheme> AddLoanSchemeAsync(LoanSchemeDto loanSchemeDto);
        Task<bool> UpdateLoanSchemeAsync(int id, LoanSchemeDto loanSchemeDto);
        Task<bool> DeleteLoanSchemeAsync(int id);

        // Other admin functions (FR1.3, FR1.4, FR1.5)
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    }

}
