using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class LoanBankService:ILoanBankService
    {
        private readonly ILoanBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public LoanBankService(ILoanBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<LoanBankDto> AddBankAsync(LoanBankDto bankDto)
        {
            var bank = _mapper.Map<LoanBank>(bankDto);
            await _bankRepository.AddBankAsync(bank);
            return _mapper.Map<LoanBankDto>(bank);
        }

        public async Task<IEnumerable<LoanBankDto>> GetAllBanksAsync()
        {
            var banks = await _bankRepository.GetAllBanksAsync();
            return _mapper.Map<IEnumerable<LoanBankDto>>(banks);
        }

        public async Task<LoanBankDto> GetBankByIdAsync(int id)
        {
            var bank = await _bankRepository.GetBankByIdAsync(id);
            return _mapper.Map<LoanBankDto>(bank);
        }

        public async Task<bool> UpdateBankAsync(LoanBankDto bankDto)
        {
            var bank = _mapper.Map<LoanBank>(bankDto);
            return await _bankRepository.UpdateBankAsync(bank);
        }

        public async Task<bool> DeleteBankAsync(int id)
        {
            return await _bankRepository.DeleteBankAsync(id);
        }
    
    }
}
