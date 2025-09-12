using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public class SystemRepository:ISystemRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetCustomerCountAsync()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<int> GetLoanOfficerCountAsync()
        {
            return await _context.LoanOfficers.CountAsync();
        }

        public async Task<Dictionary<ApplicationStatus, int>> GetApplicationStatusCountsAsync()
        {
            return await _context.LoanApplications
                .GroupBy(la => la.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Status, x => x.Count);
        }

        public async Task<IEnumerable<LoanApplication>> GetLoanApplicationReportAsync()
        {
            // Eagerly load related entities to provide a complete report
            return await _context.LoanApplications
                .Include(la => la.Customer)
                .Include(la => la.LoanOfficer)
                .Include(la => la.LoanScheme)
                .ToListAsync();
        }

        public async Task<int> GetDisbursedLoanCountAsync()
        {
            return await _context.LoanApplications
                .CountAsync(la => la.Status == ApplicationStatus.Disbursed);
        }

        public async Task<decimal> GetTotalDisbursedAmountAsync()
        {
            return await _context.LoanApplications
                .Where(la => la.Status == ApplicationStatus.Disbursed)
                .SumAsync(la => la.LoanAmount);
        }

        public async Task<int> GetRepaidLoanCountAsync()
        {
            return await _context.LoanApplications
                .CountAsync(la => la.Status == ApplicationStatus.Repaid);
        }

    }
}
