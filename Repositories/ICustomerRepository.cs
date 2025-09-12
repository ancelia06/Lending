using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Retrieves a Customer from the database by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the customer.</param>
        /// <returns>A Customer object if found, otherwise null.</returns>
        Task<Customer> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves a Customer from the database by their unique PanId.
        /// </summary>
        /// <param name="panId">The unique PAN ID of the customer.</param>
        /// <returns>A Customer object if found, otherwise null.</returns>
        Task<Customer> GetByPanIdAsync(string panId);

        /// <summary>
        /// Adds a new Customer to the database.
        /// </summary>
        /// <param name="customer">The Customer object to add.</param>
        Task AddAsync(Customer customer);

        /// <summary>
        /// Updates an existing Customer's information in the database.
        /// </summary>
        /// <param name="customer">The updated Customer object.</param>
        Task UpdateAsync(Customer customer);

        /// <summary>
        /// Deletes a Customer from the database by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the customer to delete.</param>
        Task DeleteAsync(int id);

    }
}
