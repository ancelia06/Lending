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
    public class LoanSchemeController : ControllerBase
    {
        private readonly ILoanSchemeService _loanSchemeService;

        public LoanSchemeController(ILoanSchemeService loanSchemeService)
        {
            _loanSchemeService = loanSchemeService;
        }

        // FR1.1: Add a new loan scheme (Loan Admin)
        // POST: api/LoanScheme
        [HttpPost]
        public async Task<IActionResult> AddLoanScheme([FromBody] LoanSchemeDto loanSchemeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newScheme = await _loanSchemeService.AddLoanSchemeAsync(loanSchemeDto);
            return CreatedAtAction(nameof(GetLoanSchemeById), new { id = newScheme.LoanSchemeId }, newScheme);
        }

        // FR1.1 & FR3.2: Get a list of all loan schemes
        // This endpoint is used by both Admin (to manage) and Customer (to view)
        // GET: api/LoanScheme
        [HttpGet]
        public async Task<IActionResult> GetAllLoanSchemes()
        {
            var loanSchemes = await _loanSchemeService.GetAllLoanSchemesAsync();
            return Ok(loanSchemes);
        }

        // FR1.1 & FR3.2: Get details of a single loan scheme
        // GET: api/LoanScheme/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanSchemeById(int id)
        {
            var loanScheme = await _loanSchemeService.GetLoanSchemeByIdAsync(id);
            if (loanScheme == null)
            {
                return NotFound();
            }
            return Ok(loanScheme);
        }

        // FR1.1: Update an existing loan scheme (Loan Admin)
        // PUT: api/LoanScheme/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoanScheme(int id, [FromBody] LoanSchemeDto loanSchemeDto)
        {
            if (id != loanSchemeDto.LoanSchemeId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _loanSchemeService.UpdateLoanSchemeAsync(loanSchemeDto);
            if (!result)
            {
                return NotFound("Loan scheme not found or update failed.");
            }
            return NoContent(); // 204 No Content for successful update
        }

        // FR1.1: Delete a loan scheme (Loan Admin)
        // DELETE: api/LoanScheme/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanScheme(int id)
        {
            var result = await _loanSchemeService.DeleteLoanSchemeAsync(id);
            if (!result)
            {
                return NotFound("Loan scheme not found.");
            }
            return NoContent(); // 204 No Content for successful deletion
        }

    }
}
