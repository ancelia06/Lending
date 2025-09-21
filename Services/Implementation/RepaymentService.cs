using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class RepaymentService : IRepaymentService
    {
        private readonly IRepaymentRepository _repaymentRepository;
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly IMapper _mapper;

        public RepaymentService(
            IRepaymentRepository repaymentRepository,
            ILoanApplicationRepository loanApplicationRepository,
            IMapper mapper)
        {
            _repaymentRepository = repaymentRepository;
            _loanApplicationRepository = loanApplicationRepository;
            _mapper = mapper;
        }

        // FR3.4: Make a new loan repayment and calculate interest/principal
        public async Task<RepaymentDto> MakeRepaymentAsync(RepaymentDto repaymentDto)
        {
            var loanApplication = await _loanApplicationRepository.GetLoanApplicationByIdAsync(repaymentDto.LoanApplicationId);

            if (loanApplication == null)
            {
                return null;
            }

            // Get the total outstanding balance (This is a simplified approach)
            // A more complex system would calculate outstanding principal, interest accrued, etc.
            var outstandingBalance = loanApplication.LoanAmount;

            // For a simple fixed-rate loan, a basic principal and interest calculation
            // can be done. This is a simplified example.
            var interestRate = loanApplication.LoanScheme.InterestRate;
            var monthlyInterest = outstandingBalance * (interestRate / 100) / 12;

            decimal principalPaid = repaymentDto.Amount - monthlyInterest;
            decimal interestPaid = monthlyInterest;

            // Ensure principal paid isn't negative
            if (principalPaid < 0)
            {
                principalPaid = 0;
                interestPaid = repaymentDto.Amount;
            }

            var repayment = _mapper.Map<Repayment>(repaymentDto);
            repayment.PrincipalPaid = principalPaid;
            repayment.InterestPaid = interestPaid;
            repayment.PaymentDate = DateTime.UtcNow;
            repayment.Status = RepaymentStatus.Completed; // Set status to completed

            await _repaymentRepository.AddRepaymentAsync(repayment);

            // Update the loan application's remaining balance
            loanApplication.RemainingBalance -= principalPaid;
            await _loanApplicationRepository.UpdateLoanApplicationStatusAsync(loanApplication);

            return _mapper.Map<RepaymentDto>(repayment);
        }

        // FR3.4: Get a customer's full repayment history
        public async Task<IEnumerable<RepaymentDto>> GetRepaymentHistoryForCustomerAsync(int customerId)
        {
            var repayments = await _repaymentRepository.GetRepaymentHistoryForCustomerAsync(customerId);
            return _mapper.Map<IEnumerable<RepaymentDto>>(repayments);
        }

        // Get details of a specific repayment
        public async Task<RepaymentDto> GetRepaymentByIdAsync(int repaymentId)
        {
            var repayment = await _repaymentRepository.GetRepaymentByIdAsync(repaymentId);
            return _mapper.Map<RepaymentDto>(repayment);
        }

    }

}
