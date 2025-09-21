using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;
using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc.ViewComponents;


namespace Lending_CapstoneProject.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> RegisterCustomerAsync(CustomerRegistrationDto registrationDto)
        {
            // Check for existing user by email, Aadhar ID, or PAN ID
            if (await IsEmailInUse(registrationDto.Email))
            {
                throw new ApplicationException("Email is already registered.");
            }
            if (await IsAadharIdInUse(registrationDto.AadharId))
            {
                throw new ApplicationException("Aadhar ID is already registered.");
            }
            if (await IsPanIdInUse(registrationDto.PanId))
            {
                throw new ApplicationException("PAN ID is already registered.");
            }

            // Map DTO to Model
            var customer = _mapper.Map<Customer>(registrationDto);

            // Hash the password and assign it to the PasswordHash property
            customer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);
            customer.UserType = UserType.Customer;

            return await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task<CustomerDto> GetCustomerProfileAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return null;
            }
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<bool> UpdateCustomerProfileAsync(int customerId, CustomerProfileDto profileDto)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (existingCustomer == null)
            {
                return false;
            }

            _mapper.Map(profileDto, existingCustomer);
            return await _customerRepository.UpdateCustomerAsync(existingCustomer);
        }

        public async Task<bool> IsEmailInUse(string email)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(email);
            return customer != null;
        }

        public async Task<bool> IsAadharIdInUse(string aadharId)
        {
            var customer = await _customerRepository.GetCustomerByAadharIdAsync(aadharId);
            return customer != null;
        }

        public async Task<bool> IsPanIdInUse(string panId)
        {
            var customer = await _customerRepository.GetCustomerByPanIdAsync(panId);
            return customer != null;
        }


    }
}
