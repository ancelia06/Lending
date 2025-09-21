//using Lending_CapstoneProject.Data;
//using Lending_CapstoneProject.Models;
//using Microsoft.EntityFrameworkCore;
//using Lending_CapstoneProject.Repositories.Interface;


//namespace Lending_CapstoneProject.Repositories.Implementation
//{
//    public class LoanCompanyRepository : ILoanCompanyRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public LoanCompanyRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<LoanBank> GetAsync()
//        {
//            return await _context.LoanCompanies.FirstOrDefaultAsync();
//        }

//        public async Task AddAsync(LoanBank company)
//        {
//            await _context.LoanCompanies.AddAsync(company);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(LoanBank company)
//        {
//            _context.LoanCompanies.Update(company);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var company = await GetAsync();
//            if (company != null)
//            {
//                _context.LoanCompanies.Remove(company);
//                await _context.SaveChangesAsync();
//            }
//        }

//    }
//}

