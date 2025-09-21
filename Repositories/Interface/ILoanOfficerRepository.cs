using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface ILoanOfficerRepository
    {
        // CRUD operations for LoanAdmin (FR1.2)
        Task AddLoanOfficerAsync(LoanOfficer loanOfficer);
        Task<LoanOfficer> GetLoanOfficerByIdAsync(int id);
        Task<IEnumerable<LoanOfficer>> GetAllLoanOfficersAsync();
        Task<bool> UpdateLoanOfficerAsync(LoanOfficer loanOfficer);
        Task<bool> DeleteLoanOfficerAsync(int id);

        // Automated assignment logic (FR4.1)
        Task<LoanOfficer> GetAssignedOfficerByBranchId(int branchId);

    }
}
