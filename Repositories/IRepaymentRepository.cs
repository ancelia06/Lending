using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface IRepaymentRepository
    {
        /// <summary>
        /// Retrieves a Repayment record from the database by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the repayment.</param>
        /// <returns>A Repayment object if found, otherwise null.</returns>
        Task<Repayment> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all repayment records for a specific loan application.
        /// </summary>
        /// <param name="loanApplicationId">The unique ID of the loan application.</param>
        /// <returns>A collection of all Repayment objects for the specified loan.</returns>
        Task<IEnumerable<Repayment>> GetByLoanApplicationIdAsync(int loanApplicationId);

        /// <summary>
        /// Adds a new Repayment record to the database.
        /// </summary>
        /// <param name="repayment">The Repayment object to add.</param>
        Task AddAsync(Repayment repayment);

        /// <summary>
        /// Updates an existing Repayment record in the database.
        /// </summary>
        /// <param name="repayment">The updated Repayment object.</param>
        Task UpdateAsync(Repayment repayment);

        /// <summary>
        /// Deletes a Repayment record from the database by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the repayment to delete.</param>
        Task DeleteAsync(int id);

    }
}
