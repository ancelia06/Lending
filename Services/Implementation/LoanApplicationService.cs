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
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public LoanApplicationService(
            ILoanApplicationRepository loanApplicationRepository,
            ILoanOfficerRepository loanOfficerRepository,
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _loanOfficerRepository = loanOfficerRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // FR3.3: Apply for a loan by a customer
        public async Task<LoanApplicationDto> ApplyForLoanAsync(LoanApplicationDto loanApplicationDto)
        {
            var loanApplication = _mapper.Map<LoanApplication>(loanApplicationDto);

            // FR4.1: Auto-assign loan officer based on customer city
            var customer = await _customerRepository.GetCustomerByIdAsync(loanApplication.CustomerId);
            // Corrected error: Check for valid BranchId assuming it's a non-nullable int
            if (customer != null && customer.BranchId != 0)
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
        public async Task<IEnumerable<LoanApplicationDto>> GetNpaLoansAsync()
        {
            // NPA logic: Disbursed loans with outstanding balance and no repayments for >90 days
            var allLoans = await _loanApplicationRepository.GetAllAsync();
            var npaLoans = allLoans
                .Where(loan =>
                    loan.ApplicationStatus == ApplicationStatus.Disbursed &&
                    loan.RemainingBalance > 0 &&
                    (!loan.Repayments.Any() ||
                     loan.Repayments.Max(r => r.PaymentDate) < DateTime.UtcNow.AddDays(-90))
                )
                .Select(loan => new LoanApplicationDto
                {
                    LoanApplicationId = loan.LoanApplicationId,
                    LoanType = loan.LoanType,
                    LoanAmount = loan.LoanAmount,
                    RepaymentMethod = loan.RepaymentMethod,
                    LoanSchemeId = loan.LoanSchemeId,
                    CustomerId = loan.CustomerId,
                    SchemeName = loan.LoanScheme?.SchemeName,
                    InterestRate = loan.LoanScheme?.InterestRate ?? 0,
                    Status = loan.ApplicationStatus,
                    ApplicationDate = loan.ApplicationDate,
                    CustomerName = loan.Customer?.Name
                })
                .ToList();

            return npaLoans;
        }
    }

}


