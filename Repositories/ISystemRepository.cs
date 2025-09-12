using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories
{
    public interface ISystemRepository
    {
        /// <summary>
        /// Retrieves the total count of registered customers.
        /// </summary>
        /// <returns>The total number of customers.</returns>
        Task<int> GetCustomerCountAsync();

        /// <summary>
        /// Retrieves the total count of active loan officers.
        /// </summary>
        /// <returns>The total number of loan officers.</returns>
        Task<int> GetLoanOfficerCountAsync();

        /// <summary>
        /// Retrieves the count of loan applications by their status.
        /// </summary>
        /// <returns>A dictionary containing the count for each application status.</returns>
        Task<Dictionary<ApplicationStatus, int>> GetApplicationStatusCountsAsync();

        /// <summary>
        /// Retrieves a report of all loan applications with their current status.
        /// </summary>
        /// <returns>A collection of LoanApplication objects for reporting purposes.</returns>
        Task<IEnumerable<LoanApplication>> GetLoanApplicationReportAsync();

        /// <summary>
        /// Retrieves the total number of loans disbursed.
        /// </summary>
        /// <returns>The total number of loans that have been disbursed.</returns>
        Task<int> GetDisbursedLoanCountAsync();

        /// <summary>
        /// Retrieves the total amount of money disbursed across all approved loans.
        /// </summary>
        /// <returns>The total sum of all disbursed loans.</returns>
        Task<decimal> GetTotalDisbursedAmountAsync();

        /// <summary>
        /// Retrieves the total number of loans fully repaid.
        /// </summary>
        /// <returns>The total number of loans with a status of 'Repaid'.</returns>
        Task<int> GetRepaidLoanCountAsync();

    }
}
