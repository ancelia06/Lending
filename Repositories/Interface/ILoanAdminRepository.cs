using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface ILoanAdminRepository
    {
        // CRUD operations for LoanAdmin
        Task<LoanAdmin> GetLoanAdminByIdAsync(int id);
        Task<LoanAdmin> GetLoanAdminByUsernameAsync(string username);
        Task<IEnumerable<LoanAdmin>> GetAllLoanAdminsAsync();
        Task AddLoanAdminAsync(LoanAdmin loanAdmin);
        Task<bool> UpdateLoanAdminAsync(LoanAdmin loanAdmin);
        Task<bool> DeleteLoanAdminAsync(int id);

        // Management of Loan Officers (FR1.2)
        Task<IEnumerable<LoanOfficer>> GetAllLoanOfficersAsync();
        Task<LoanOfficer> GetLoanOfficerByIdAsync(int id);
        Task AddLoanOfficerAsync(LoanOfficer loanOfficer);
        Task<bool> UpdateLoanOfficerAsync(LoanOfficer loanOfficer);
        Task<bool> DeleteLoanOfficerAsync(int id);

        // Management of Loan Schemes (FR1.1)
        Task<IEnumerable<LoanScheme>> GetAllLoanSchemesAsync();
        Task<LoanScheme> GetLoanSchemeByIdAsync(int id);
        Task AddLoanSchemeAsync(LoanScheme loanScheme);
        Task<bool> UpdateLoanSchemeAsync(LoanScheme loanScheme);
        Task<bool> DeleteLoanSchemeAsync(int id);

        // Other admin functions
        Task<IEnumerable<Customer>> GetAllCustomersAsync();


    }
}
