using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface ILoanOfficerService
    {
        // FR2.1: View pending loan applications assigned to the officer
        Task<IEnumerable<LoanApplicationDto>> GetPendingApplicationsAsync(int loanOfficerId);

        // FR2.3: Approve or reject a loan application
        Task<bool> UpdateLoanApplicationStatusAsync(int loanApplicationId, LoanApplicationStatusUpdateDto statusUpdateDto);

        // FR2.2: Get a specific loan application and its related customer details
        Task<LoanApplicationDto> GetApplicationDetailsAsync(int loanApplicationId);

        // FR2.4: Handle customer queries (This could be a placeholder for a more complex feature)
        Task<bool> RespondToCustomerQueryAsync(int customerId, string message);

    }

}
