using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class LoanBranchService:ILoanBranchService
    {
        private readonly ILoanBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public LoanBranchService(ILoanBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<LoanBranchDto> AddBranchAsync(LoanBranchDto branchDto)
        {
            var branch = _mapper.Map<LoanBranch>(branchDto);
            await _branchRepository.AddBranchAsync(branch);
            return _mapper.Map<LoanBranchDto>(branch);
        }

        public async Task<IEnumerable<LoanBranchDto>> GetAllBranchesAsync()
        {
            var branches = await _branchRepository.GetAllBranchesAsync();
            return _mapper.Map<IEnumerable<LoanBranchDto>>(branches);
        }

        public async Task<LoanBranchDto> GetBranchByIdAsync(int id)
        {
            var branch = await _branchRepository.GetBranchByIdAsync(id);
            return _mapper.Map<LoanBranchDto>(branch);
        }

        public async Task<bool> UpdateBranchAsync(LoanBranchDto branchDto)
        {
            var branch = _mapper.Map<LoanBranch>(branchDto);
            return await _branchRepository.UpdateBranchAsync(branch);
        }

        public async Task<bool> DeleteBranchAsync(int id)
        {
            return await _branchRepository.DeleteBranchAsync(id);
        }

    }
}
