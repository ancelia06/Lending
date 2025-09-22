using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface ILoanApplicationService
    {
        // For Customer (FR3.3)
        Task<LoanApplicationDto> ApplyForLoanAsync(LoanApplicationDto loanApplicationDto);

        // For Loan Officer (FR2.1, FR2.2, FR2.3)
        Task<IEnumerable<LoanApplicationDto>> GetPendingApplicationsForOfficerAsync(int loanOfficerId);
        Task<bool> UpdateLoanApplicationStatusAsync(int loanApplicationId, LoanApplicationStatusUpdateDto statusUpdateDto);

        // For both Customer and Loan Officer
        Task<LoanApplicationDto> GetLoanApplicationDetailsAsync(int loanApplicationId);
        // For Admin: Monitor NPAs (Non-Performing Assets)
        Task<IEnumerable<LoanApplicationDto>> GetNpaLoansAsync();


    }

}
