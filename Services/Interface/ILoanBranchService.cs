using Lending_CapstoneProject.DTOs;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface ILoanBranchService
    {
        Task<LoanBranchDto> AddBranchAsync(LoanBranchDto branchDto);
        Task<IEnumerable<LoanBranchDto>> GetAllBranchesAsync();
        Task<LoanBranchDto> GetBranchByIdAsync(int id);
        Task<bool> UpdateBranchAsync(LoanBranchDto branchDto);
        Task<bool> DeleteBranchAsync(int id);
    }

}

