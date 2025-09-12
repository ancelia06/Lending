using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface ILoanCompanyRepository
    {
        Task<LoanCompany> GetAsync();

        /// <summary>
        /// Adds a new LoanCompany record to the database.
        /// </summary>
        /// <param name="company">The LoanCompany object to add.</param>
        Task AddAsync(LoanCompany company);

        /// <summary>
        /// Updates the existing LoanCompany record in the database.
        /// </summary>
        /// <param name="company">The updated LoanCompany object.</param>
        Task UpdateAsync(LoanCompany company);

        /// <summary>
        /// Deletes the LoanCompany record from the database.
        /// </summary>
        /// <param name="id">The unique ID of the loan company to delete.</param>
        Task DeleteAsync(int id);
    }
}
