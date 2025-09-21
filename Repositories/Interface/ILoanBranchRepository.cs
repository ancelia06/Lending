using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface ILoanBranchRepository
    {
        Task AddBranchAsync(LoanBranch branch);
        Task<LoanBranch> GetBranchByIdAsync(int id);
        Task<IEnumerable<LoanBranch>> GetAllBranchesAsync();
        Task<bool> UpdateBranchAsync(LoanBranch branch);
        Task<bool> DeleteBranchAsync(int id);

    }
}
