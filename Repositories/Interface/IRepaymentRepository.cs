using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface IRepaymentRepository
    {

        // FR3.4: Make loan repayments and view repayment history
        Task AddRepaymentAsync(Repayment repayment);
        Task<Repayment> GetRepaymentByIdAsync(int id);
        Task<IEnumerable<Repayment>> GetRepaymentsByLoanApplicationIdAsync(int loanApplicationId);
        Task<IEnumerable<Repayment>> GetRepaymentHistoryForCustomerAsync(int customerId);
        Task<bool> UpdateRepaymentAsync(Repayment repayment);
        Task<bool> DeleteRepaymentAsync(int id);
        Task<IEnumerable<Repayment>> GetAllRepaymentsAsync();


    }
}
