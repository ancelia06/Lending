using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;
using BCrypt.Net;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class LoanAdminService : ILoanAdminService
    {
        private readonly ILoanAdminRepository _loanAdminRepository;
        private readonly IMapper _mapper;

        public LoanAdminService(ILoanAdminRepository loanAdminRepository, IMapper mapper)
        {
            _loanAdminRepository = loanAdminRepository;
            _mapper = mapper;
        }

        public async Task<LoanAdmin> LoginAsync(LoginDto loginDto)
        {
            var loanAdmin = await _loanAdminRepository.GetLoanAdminByUsernameAsync(loginDto.UserName);

            if (loanAdmin == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, loanAdmin.PasswordHash))
            {
                return null;
            }

            return loanAdmin;
        }

        public async Task<IEnumerable<LoanOfficerDto>> GetAllLoanOfficersAsync()
        {
            var loanOfficers = await _loanAdminRepository.GetAllLoanOfficersAsync();
            return _mapper.Map<IEnumerable<LoanOfficerDto>>(loanOfficers);
        }

        public async Task<LoanOfficer> AddLoanOfficerAsync(LoanOfficerDto loanOfficerDto)
        {
            var loanOfficer = _mapper.Map<LoanOfficer>(loanOfficerDto);
            loanOfficer.PasswordHash = BCrypt.Net.BCrypt.HashPassword("DefaultPassword123");
            loanOfficer.UserType = UserType.LoanOfficer;

            await _loanAdminRepository.AddLoanOfficerAsync(loanOfficer);
            return loanOfficer;
        }

        public async Task<bool> UpdateLoanOfficerAsync(int id, LoanOfficerDto loanOfficerDto)
        {
            var existingLoanOfficer = await _loanAdminRepository.GetLoanOfficerByIdAsync(id);
            if (existingLoanOfficer == null)
            {
                return false;
            }

            _mapper.Map(loanOfficerDto, existingLoanOfficer);
            return await _loanAdminRepository.UpdateLoanOfficerAsync(existingLoanOfficer);
        }

        public async Task<bool> DeleteLoanOfficerAsync(int id)
        {
            return await _loanAdminRepository.DeleteLoanOfficerAsync(id);
        }

        public async Task<IEnumerable<LoanSchemeDto>> GetAllLoanSchemesAsync()
        {
            var loanSchemes = await _loanAdminRepository.GetAllLoanSchemesAsync();
            return _mapper.Map<IEnumerable<LoanSchemeDto>>(loanSchemes);
        }

        public async Task<LoanScheme> AddLoanSchemeAsync(LoanSchemeDto loanSchemeDto)
        {
            var loanScheme = _mapper.Map<LoanScheme>(loanSchemeDto);
            await _loanAdminRepository.AddLoanSchemeAsync(loanScheme);
            return loanScheme;
        }

        public async Task<bool> UpdateLoanSchemeAsync(int id, LoanSchemeDto loanSchemeDto)
        {
            var existingLoanScheme = await _loanAdminRepository.GetLoanSchemeByIdAsync(id);
            if (existingLoanScheme == null)
            {
                return false;
            }

            _mapper.Map(loanSchemeDto, existingLoanScheme);
            return await _loanAdminRepository.UpdateLoanSchemeAsync(existingLoanScheme);
        }

        public async Task<bool> DeleteLoanSchemeAsync(int id)
        {
            return await _loanAdminRepository.DeleteLoanSchemeAsync(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _loanAdminRepository.GetAllCustomersAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }



    }

}
