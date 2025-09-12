using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface ILoanApplicationRepository
    {
        /// <summary>
        /// Retrieves a LoanApplication from the database by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the loan application.</param>
        /// <returns>A LoanApplication object if found, otherwise null.</returns>
        Task<LoanApplication> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all pending loan applications from the database.
        /// </summary>
        /// <returns>A collection of all pending LoanApplication objects.</returns>
        Task<IEnumerable<LoanApplication>> GetAllPendingApplicationsAsync();

        /// <summary>
        /// Retrieves all loan applications submitted by a specific customer.
        /// </summary>
        /// <param name="customerId">The unique ID of the customer.</param>
        /// <returns>A collection of LoanApplication objects for the specified customer.</returns>
        Task<IEnumerable<LoanApplication>> GetApplicationsByCustomerIdAsync(int customerId);

        /// <summary>
        /// Retrieves all loan applications assigned to a specific loan officer.
        /// </summary>
        /// <param name="officerId">The unique ID of the loan officer.</param>
        /// <returns>A collection of LoanApplication objects assigned to the specified officer.</returns>
        Task<IEnumerable<LoanApplication>> GetApplicationsByOfficerIdAsync(int officerId);

        /// <summary>
        /// Adds a new LoanApplication to the database.
        /// </summary>
        /// <param name="application">The LoanApplication object to add.</param>
        Task AddAsync(LoanApplication application);

        /// <summary>
        /// Updates an existing LoanApplication's status in the database.
        /// </summary>
        /// <param name="applicationId">The unique ID of the loan application to update.</param>
        /// <param name="status">The new status for the loan application.</param>
        Task UpdateStatusAsync(int applicationId, ApplicationStatus status);

        /// <summary>
        /// Deletes a LoanApplication from the database by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the loan application to delete.</param>
        Task DeleteAsync(int id);
    }
}
