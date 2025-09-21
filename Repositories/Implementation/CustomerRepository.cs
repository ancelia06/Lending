using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Data;
using Microsoft.EntityFrameworkCore;
using Lending_CapstoneProject.Repositories.Interface;
using System.Linq.Expressions;

namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Customer> GetCustomerByAadharIdAsync(string aadharId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.AadharId == aadharId);
        }

        public async Task<Customer> GetCustomerByPanIdAsync(string panId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.PanId == panId);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.CustomerId);
            if (existingCustomer == null)
            {
                return false;
            }

            _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customerToDelete = await _context.Customers.FindAsync(customerId);
            if (customerToDelete == null)
            {
                return false;
            }

            _context.Customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
