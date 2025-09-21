using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lending_CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanAdminController : ControllerBase
    {
        private readonly ILoanAdminService _loanAdminService;

        public LoanAdminController(ILoanAdminService loanAdminService)
        {
            _loanAdminService = loanAdminService;
        }

        // FR1.1: Add Loan Scheme
        [HttpPost("schemes")]
        public async Task<IActionResult> AddLoanScheme([FromBody] LoanSchemeDto loanSchemeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newScheme = await _loanAdminService.AddLoanSchemeAsync(loanSchemeDto);
            return CreatedAtAction(nameof(GetLoanSchemes), new { id = newScheme.LoanSchemeId }, newScheme);
        }

        // FR1.1: Get All Loan Schemes
        [HttpGet("schemes")]
        public async Task<IActionResult> GetLoanSchemes()
        {
            var schemes = await _loanAdminService.GetAllLoanSchemesAsync();
            return Ok(schemes);
        }

        // FR1.1: Update Loan Scheme
        [HttpPut("schemes/{id}")]
        public async Task<IActionResult> UpdateLoanScheme(int id, [FromBody] LoanSchemeDto loanSchemeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _loanAdminService.UpdateLoanSchemeAsync(id, loanSchemeDto);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // FR1.1: Delete Loan Scheme
        [HttpDelete("schemes/{id}")]
        public async Task<IActionResult> DeleteLoanScheme(int id)
        {
            var deleted = await _loanAdminService.DeleteLoanSchemeAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        // FR1.2: Add Loan Officer
        [HttpPost("officers")]
        public async Task<IActionResult> AddLoanOfficer([FromBody] LoanOfficerDto loanOfficerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newOfficer = await _loanAdminService.AddLoanOfficerAsync(loanOfficerDto);
            return CreatedAtAction(nameof(GetAllLoanOfficers), new { id = newOfficer.UserId }, newOfficer);
        }

        // FR1.2: Get All Loan Officers
        [HttpGet("officers")]
        public async Task<IActionResult> GetAllLoanOfficers()
        {
            var officers = await _loanAdminService.GetAllLoanOfficersAsync();
            return Ok(officers);
        }

        // FR1.2: Update Loan Officer
        [HttpPut("officers/{id}")]
        public async Task<IActionResult> UpdateLoanOfficer(int id, [FromBody] LoanOfficerDto loanOfficerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _loanAdminService.UpdateLoanOfficerAsync(id, loanOfficerDto);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // FR1.2: Delete Loan Officer
        [HttpDelete("officers/{id}")]
        public async Task<IActionResult> DeleteLoanOfficer(int id)
        {
            var deleted = await _loanAdminService.DeleteLoanOfficerAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        // FR1.3: View All Customers
        [HttpGet("customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _loanAdminService.GetAllCustomersAsync();
            return Ok(customers);
        }

    }
}
