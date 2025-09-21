using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface ILoanSchemeService
    {
        // FR1.1: CRUD operations for a Loan Admin
        Task<LoanSchemeDto> AddLoanSchemeAsync(LoanSchemeDto loanSchemeDto);
        Task<bool> UpdateLoanSchemeAsync(LoanSchemeDto loanSchemeDto);
        Task<bool> DeleteLoanSchemeAsync(int id);

        // FR1.1 & FR3.2: Get a list of all available loan schemes for both Admin and Customer views
        Task<IEnumerable<LoanSchemeDto>> GetAllLoanSchemesAsync();

        // Retrieve details of a specific loan scheme
        Task<LoanSchemeDto> GetLoanSchemeByIdAsync(int id);

    }

}
