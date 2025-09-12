using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface ILoanAdminRepository
    {
        /// <summary>
        /// Retrieves a LoanAdmin from the database by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the loan administrator.</param>
        /// <returns>A LoanAdmin object if found, otherwise null.</returns>
        Task<LoanAdmin> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all LoanAdmin records from the database.
        /// </summary>
        /// <returns>A collection of all LoanAdmin objects.</returns>
        Task<IEnumerable<LoanAdmin>> GetAllAdminsAsync();

        /// <summary>
        /// Adds a new LoanAdmin to the database.
        /// </summary>
        /// <param name="admin">The LoanAdmin object to add.</param>
        Task AddAsync(LoanAdmin admin);

        /// <summary>
        /// Updates an existing LoanAdmin's information in the database.
        /// </summary>
        /// <param name="admin">The updated LoanAdmin object.</param>
        Task UpdateAsync(LoanAdmin admin);

        /// <summary>
        /// Deletes a LoanAdmin from the database by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the loan administrator to delete.</param>
        Task DeleteAsync(int id);
    }
}
