        using AutoMapper;
        using Lending_CapstoneProject.DTOs;
        using Lending_CapstoneProject.Models;
        using Lending_CapstoneProject.Repositories.Interface;
        using Lending_CapstoneProject.Services.Interface;
        using System.Threading.Tasks;
        using System.Collections.Generic;

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

                    var outstandingBalance = loanApplication.LoanAmount;
                    var interestRate = loanApplication.LoanScheme.InterestRate;
                    var monthlyInterest = outstandingBalance * (interestRate / 100) / 12;

                    decimal principalPaid = repaymentDto.Amount - monthlyInterest;
                    decimal interestPaid = monthlyInterest;

                    if (principalPaid < 0)
                    {
                        principalPaid = 0;
                        interestPaid = repaymentDto.Amount;
                    }

                    var repayment = _mapper.Map<Repayment>(repaymentDto);
                    repayment.PrincipalPaid = principalPaid;
                    repayment.InterestPaid = interestPaid;
                    repayment.PaymentDate = DateTime.UtcNow;
                    repayment.Status = RepaymentStatus.Completed;

                    await _repaymentRepository.AddRepaymentAsync(repayment);

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

                // Implementation of RecordRepaymentAsync
                public async Task RecordRepaymentAsync(RepaymentDto repaymentDto)
                {
                    var repayment = _mapper.Map<Repayment>(repaymentDto);
                    repayment.PaymentDate = DateTime.UtcNow;
                    await _repaymentRepository.AddRepaymentAsync(repayment);
                }
            }
        }
