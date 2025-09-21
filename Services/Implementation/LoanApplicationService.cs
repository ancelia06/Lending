using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Implementation;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly ILoanOfficerRepository _loanOfficerRepository;
        private readonly IMapper _mapper;

        public LoanApplicationService(
            ILoanApplicationRepository loanApplicationRepository,
            ILoanOfficerRepository loanOfficerRepository,
            IMapper mapper)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _loanOfficerRepository = loanOfficerRepository;
            _mapper = mapper;
        }

        // FR3.3: Apply for a loan by a customer
        public async Task<LoanApplicationDto> ApplyForLoanAsync(LoanApplicationDto loanApplicationDto)
        {
            var loanApplication = _mapper.Map<LoanApplication>(loanApplicationDto);

            // FR4.1: Auto-assign loan officer based on customer city
            var customer = await _loanApplicationRepository.GetCustomerByIdAsync(loanApplication.CustomerId);
            if (customer != null)
            {
                var assignedOfficer = await _loanOfficerRepository.GetAssignedOfficerByBranchId(customer.BranchId);
                if (assignedOfficer != null)
                {
                    loanApplication.LoanOfficerId = assignedOfficer.UserId;
                }
            }

            // Set initial status and dates
            loanApplication.ApplicationStatus = ApplicationStatus.Pending;
            loanApplication.ApplicationDate = DateTime.UtcNow;
            loanApplication.StatusUpdatedDate = DateTime.UtcNow;

            await _loanApplicationRepository.AddLoanApplicationAsync(loanApplication);

            return _mapper.Map<LoanApplicationDto>(loanApplication);
        }

        // FR2.1: View pending loan applications for a specific loan officer
        public async Task<IEnumerable<LoanApplicationDto>> GetPendingApplicationsForOfficerAsync(int loanOfficerId)
        {
            var pendingApplications = await _loanApplicationRepository.GetLoanApplicationsByOfficerIdAsync(loanOfficerId);
            return _mapper.Map<IEnumerable<LoanApplicationDto>>(pendingApplications.Where(app => app.ApplicationStatus == ApplicationStatus.Pending));
        }

        // FR2.3: Update loan application status by a loan officer
        public async Task<bool> UpdateLoanApplicationStatusAsync(int loanApplicationId, LoanApplicationStatusUpdateDto statusUpdateDto)
        {
            var existingApplication = await _loanApplicationRepository.GetLoanApplicationByIdAsync(loanApplicationId);
            if (existingApplication == null)
            {
                return false;
            }

            existingApplication.ApplicationStatus = statusUpdateDto.Status;
            existingApplication.Remarks = statusUpdateDto.Remarks;
            existingApplication.StatusUpdatedDate = DateTime.UtcNow;

            // This is a crucial update. Ensure the correct officer is making the change.
            if (existingApplication.LoanOfficerId != statusUpdateDto.LoanOfficerId)
            {
                // You might want to throw an exception or return a different error.
                return false;
            }

            return await _loanApplicationRepository.UpdateLoanApplicationStatusAsync(existingApplication);
        }

        // Retrieve details of a specific loan application
        public async Task<LoanApplicationDto> GetLoanApplicationDetailsAsync(int loanApplicationId)
        {
            var loanApplication = await _loanApplicationRepository.GetLoanApplicationByIdAsync(loanApplicationId);
            if (loanApplication == null)
            {
                return null;
            }
            return _mapper.Map<LoanApplicationDto>(loanApplication);
        }


    }

}
