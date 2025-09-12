using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface ILoanSchemeRepository
    {
        /// <summary>
        /// Retrieves a LoanScheme from the database by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the loan scheme.</param>
        /// <returns>A LoanScheme object if found, otherwise null.</returns>
        Task<LoanScheme> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all LoanScheme records from the database.
        /// </summary>
        /// <returns>A collection of all LoanScheme objects.</returns>
        Task<IEnumerable<LoanScheme>> GetAllAsync();

        /// <summary>
        /// Adds a new LoanScheme to the database.
        /// </summary>
        /// <param name="scheme">The LoanScheme object to add.</param>
        Task AddAsync(LoanScheme scheme);

        /// <summary>
        /// Updates an existing LoanScheme's information in the database.
        /// </summary>
        /// <param name="scheme">The updated LoanScheme object.</param>
        Task UpdateAsync(LoanScheme scheme);

        /// <summary>
        /// Deletes a LoanScheme from the database by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the loan scheme to delete.</param>
        Task DeleteAsync(int id);
    }
}
