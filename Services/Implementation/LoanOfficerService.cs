using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class LoanOfficerService : ILoanOfficerService
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly IMapper _mapper;

        public LoanOfficerService(ILoanApplicationRepository loanApplicationRepository, IMapper mapper)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _mapper = mapper;
        }

        // FR2.1: View pending loan applications for a specific loan officer
        public async Task<IEnumerable<LoanApplicationDto>> GetPendingApplicationsAsync(int loanOfficerId)
        {
            var applications = await _loanApplicationRepository.GetLoanApplicationsByOfficerIdAsync(loanOfficerId);
            return _mapper.Map<IEnumerable<LoanApplicationDto>>(applications.Where(app => app.ApplicationStatus == ApplicationStatus.Pending));
        }

        // FR2.3: Approve or reject a loan application
        public async Task<bool> UpdateLoanApplicationStatusAsync(int loanApplicationId, LoanApplicationStatusUpdateDto statusUpdateDto)
        {
            var application = await _loanApplicationRepository.GetLoanApplicationByIdAsync(loanApplicationId);
            if (application == null)
            {
                return false;
            }

            // Ensure the officer is assigned to this application
            if (application.LoanOfficerId != statusUpdateDto.LoanOfficerId)
            {
                return false; // Unauthorized access
            }

            // Update status and remarks
            application.ApplicationStatus = statusUpdateDto.Status;
            application.Remarks = statusUpdateDto.Remarks;
            application.StatusUpdatedDate = DateTime.UtcNow;

            return await _loanApplicationRepository.UpdateLoanApplicationStatusAsync(application);
        }

        // FR2.2: Get a specific loan application and its related customer details
        public async Task<LoanApplicationDto> GetApplicationDetailsAsync(int loanApplicationId)
        {
            var application = await _loanApplicationRepository.GetLoanApplicationByIdAsync(loanApplicationId);
            if (application == null)
            {
                return null;
            }

            return _mapper.Map<LoanApplicationDto>(application);
        }

        // FR2.4: Handle customer queries
        // This is a placeholder as the SRS does not specify how queries are stored or managed.
        // It's likely an email or messaging system would be integrated here.
        public Task<bool> RespondToCustomerQueryAsync(int customerId, string message)
        {
            // Placeholder for a future implementation, e.g., an email service call.
            // For now, it just returns a successful task.
            return Task.FromResult(true);
        }

    }

}
