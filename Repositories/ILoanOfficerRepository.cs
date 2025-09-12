using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface ILoanOfficerRepository
    {
        /// <summary>
        /// Retrieves a LoanOfficer from the database by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the loan officer.</param>
        /// <returns>A LoanOfficer object if found, otherwise null.</returns>
        Task<LoanOfficer> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all LoanOfficer records from the database.
        /// </summary>
        /// <returns>A collection of all LoanOfficer objects.</returns>
        Task<IEnumerable<LoanOfficer>> GetAllOfficersAsync();

        /// <summary>
        /// Adds a new LoanOfficer to the database.
        /// </summary>
        /// <param name="officer">The LoanOfficer object to add.</param>
        Task AddAsync(LoanOfficer officer);

        /// <summary>
        /// Updates an existing LoanOfficer's information in the database.
        /// </summary>
        /// <param name="officer">The updated LoanOfficer object.</param>
        Task UpdateAsync(LoanOfficer officer);

        /// <summary>
        /// Deletes a LoanOfficer from the database by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the loan officer to delete.</param>
        Task DeleteAsync(int id);

    }
}
