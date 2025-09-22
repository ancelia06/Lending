using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Lending_CapstoneProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILoanSchemeService _loanSchemeService;

        public CustomerController(
            ICustomerService customerService,
            ILoanSchemeService loanSchemeService)
        {
            _customerService = customerService;
            _loanSchemeService = loanSchemeService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegistrationDto registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // This will handle the business logic, including checks for existing Aadhar/PAN IDs and email.
                var newCustomer = await _customerService.RegisterCustomerAsync(registrationDto);
                return CreatedAtAction(nameof(GetCustomerProfile), new { customerId = newCustomer.CustomerId }, newCustomer);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerProfile(int customerId)
        {
            var customerProfile = await _customerService.GetCustomerProfileAsync(customerId);
            if (customerProfile == null)
            {
                return NotFound();
            }
            return Ok(customerProfile);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomerProfile(int customerId, [FromBody] CustomerProfileDto profileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _customerService.UpdateCustomerProfileAsync(customerId, profileDto);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Customer needs: Browses loan schemes
        // FR1.1: Customer can view all available loan schemes.
        [HttpGet("schemes")]
        public async Task<IActionResult> GetAllLoanSchemes()
        {
            var loanSchemes = await _loanSchemeService.GetAllLoanSchemesAsync();
            return Ok(loanSchemes);
        }

    }
}
