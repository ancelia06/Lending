using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public class LoanApplicationRepository:ILoanApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoanApplication> GetByIdAsync(int id)
        {
            // Eagerly load related entities to provide a complete view of the application
            return await _context.LoanApplications
                .Include(la => la.Customer)
                .Include(la => la.LoanOfficer)
                .Include(la => la.LoanScheme)
                .FirstOrDefaultAsync(la => la.LoanApplicationId == id);
        }

        public async Task<IEnumerable<LoanApplication>> GetAllPendingApplicationsAsync()
        {
            return await _context.LoanApplications
                .Where(la => la.Status == ApplicationStatus.Pending)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanApplication>> GetApplicationsByCustomerIdAsync(int customerId)
        {
            return await _context.LoanApplications
                .Where(la => la.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanApplication>> GetApplicationsByOfficerIdAsync(int officerId)
        {
            return await _context.LoanApplications
                .Where(la => la.LoanOfficerId == officerId)
                .ToListAsync();
        }

        public async Task AddAsync(LoanApplication application)
        {
            await _context.LoanApplications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int applicationId, ApplicationStatus status)
        {
            var application = await GetByIdAsync(applicationId);
            if (application != null)
            {
                application.Status = status;
                _context.LoanApplications.Update(application);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var application = await GetByIdAsync(id);
            if (application != null)
            {
                _context.LoanApplications.Remove(application);
                await _context.SaveChangesAsync();
            }
        }

    }
}
