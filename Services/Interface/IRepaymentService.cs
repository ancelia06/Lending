using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface IRepaymentService
    {
        // FR3.4: Make a new loan repayment
        Task<RepaymentDto> MakeRepaymentAsync(RepaymentDto repaymentDto);

        // FR3.4: Get a customer's full repayment history
        Task<IEnumerable<RepaymentDto>> GetRepaymentHistoryForCustomerAsync(int customerId);

        // Get details of a specific repayment
        Task<RepaymentDto> GetRepaymentByIdAsync(int repaymentId);

        // Add the missing method definition
        Task RecordRepaymentAsync(RepaymentDto repaymentDto);
    }
}
