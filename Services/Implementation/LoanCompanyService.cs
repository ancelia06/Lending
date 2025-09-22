//using Lending_CapstoneProject.Models;
//using Lending_CapstoneProject.Repositories.Interface;
//using Lending_CapstoneProject.Services.Interface;

//namespace Lending_CapstoneProject.Services.Implementation
//{
//    public class LoanCompanyService : ILoanCompanyService
//    {
//        private readonly ILoanCompanyRepository _repository;

//        public LoanCompanyService(ILoanCompanyRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<LoanBank> GetAsync()
//        {
//            return await _repository.GetAsync();
//        }

//        public async Task AddAsync(LoanBank company)
//        {
//            await _repository.AddAsync(company);
//        }

//        public async Task UpdateAsync(LoanBank company)
//        {
//            await _repository.UpdateAsync(company);
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var existing = await _repository.GetAsync();
//            if (existing == null) return false;

//            await _repository.DeleteAsync(id);
//            return true;
//        }
//    }

//}
