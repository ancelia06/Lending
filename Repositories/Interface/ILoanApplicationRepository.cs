using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface ILoanApplicationRepository
    {

        // Add a new loan application
        Task AddLoanApplicationAsync(LoanApplication loanApplication);

        // Get a loan application by ID with related data
        Task<LoanApplication> GetLoanApplicationByIdAsync(int loanApplicationId);

        // Get a loan application by ID for a specific loan officer (FR2.1)
        Task<IEnumerable<LoanApplication>> GetLoanApplicationsByOfficerIdAsync(int officerId);

        // Get a loan application by ID for a specific customer (FR3.3)
        Task<IEnumerable<LoanApplication>> GetLoanApplicationsByCustomerIdAsync(int customerId);

        // Update the status of a loan application
        Task<bool> UpdateLoanApplicationStatusAsync(LoanApplication loanApplication);

        // Method to get a customer by ID for auto-assignment
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<LoanApplication>> GetAllAsync();



    }
}

