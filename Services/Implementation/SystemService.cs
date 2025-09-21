//using Lending_CapstoneProject.Models;
//using Lending_CapstoneProject.Repositories.Interface;
//using Lending_CapstoneProject.Services.Interface;

//namespace Lending_CapstoneProject.Services.Implementation
//{
//    public class SystemService : ISystemService
//    {
//        private readonly ISystemRepository _repository;

//        public SystemService(ISystemRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<int> GetCustomerCountAsync()
//        {
//            return await _repository.GetCustomerCountAsync();
//        }

//        public async Task<int> GetLoanOfficerCountAsync()
//        {
//            return await _repository.GetLoanOfficerCountAsync();
//        }

//        public async Task<Dictionary<ApplicationStatus, int>> GetApplicationStatusCountsAsync()
//        {
//            return await _repository.GetApplicationStatusCountsAsync();
//        }

//        public async Task<IEnumerable<LoanApplication>> GetLoanApplicationReportAsync()
//        {
//            return await _repository.GetLoanApplicationReportAsync();
//        }

//        public async Task<int> GetDisbursedLoanCountAsync()
//        {
//            return await _repository.GetDisbursedLoanCountAsync();
//        }

//        public async Task<decimal> GetTotalDisbursedAmountAsync()
//        {
//            return await _repository.GetTotalDisbursedAmountAsync();
//        }

//        public async Task<int> GetRepaidLoanCountAsync()
//        {
//            return await _repository.GetRepaidLoanCountAsync();
//        }
//    }

//}
