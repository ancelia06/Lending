using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class LoanSchemeService : ILoanSchemeService
    {
        private readonly ILoanSchemeRepository _loanSchemeRepository;
        private readonly IMapper _mapper;

        public LoanSchemeService(ILoanSchemeRepository loanSchemeRepository, IMapper mapper)
        {
            _loanSchemeRepository = loanSchemeRepository;
            _mapper = mapper;
        }

        // FR1.1: Adds a new loan scheme
        public async Task<LoanSchemeDto> AddLoanSchemeAsync(LoanSchemeDto loanSchemeDto)
        {
            var loanScheme = _mapper.Map<LoanScheme>(loanSchemeDto);
            await _loanSchemeRepository.AddLoanSchemeAsync(loanScheme);
            return _mapper.Map<LoanSchemeDto>(loanScheme);
        }

        // FR1.1: Updates an existing loan scheme
        public async Task<bool> UpdateLoanSchemeAsync(LoanSchemeDto loanSchemeDto)
        {
            var loanScheme = _mapper.Map<LoanScheme>(loanSchemeDto);
            return await _loanSchemeRepository.UpdateLoanSchemeAsync(loanScheme);
        }

        // FR1.1: Deletes a loan scheme
        public async Task<bool> DeleteLoanSchemeAsync(int id)
        {
            return await _loanSchemeRepository.DeleteLoanSchemeAsync(id);
        }

        // FR1.1 & FR3.2: Retrieves all loan schemes
        public async Task<IEnumerable<LoanSchemeDto>> GetAllLoanSchemesAsync()
        {
            var loanSchemes = await _loanSchemeRepository.GetAllLoanSchemesAsync();
            return _mapper.Map<IEnumerable<LoanSchemeDto>>(loanSchemes);
        }

        // Retrieves a single loan scheme by ID
        public async Task<LoanSchemeDto> GetLoanSchemeByIdAsync(int id)
        {
            var loanScheme = await _loanSchemeRepository.GetLoanSchemeByIdAsync(id);
            return _mapper.Map<LoanSchemeDto>(loanScheme);
        }

    }

}
