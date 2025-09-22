using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lending_CapstoneProject.DTOs;

namespace Lending_CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanBranchController : ControllerBase
    {
        private readonly ILoanBranchService _loanBranchService;

        public LoanBranchController(ILoanBranchService loanBranchService)
        {
            _loanBranchService = loanBranchService;
        }

        // POST: api/LoanBranch
        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] LoanBranchDto branchDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBranch = await _loanBranchService.AddBranchAsync(branchDto);
            return CreatedAtAction(nameof(GetBranchById), new { id = newBranch.BranchId }, newBranch);
        }

        // GET: api/LoanBranch
        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var branches = await _loanBranchService.GetAllBranchesAsync();
            return Ok(branches);
        }

        // GET: api/LoanBranch/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchById(int id)
        {
            var branch = await _loanBranchService.GetBranchByIdAsync(id);
            if (branch == null)
            {
                return NotFound("Loan branch not found.");
            }
            return Ok(branch);
        }

        // PUT: api/LoanBranch/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] LoanBranchDto branchDto)
        {
            if (id != branchDto.BranchId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _loanBranchService.UpdateBranchAsync(branchDto);
            if (!result)
            {
                return NotFound("Loan branch not found or update failed.");
            }
            return NoContent();
        }

        // DELETE: api/LoanBranch/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var result = await _loanBranchService.DeleteBranchAsync(id);
            if (!result)
            {
                return NotFound("Loan branch not found.");
            }
            return NoContent();
        }

    }
}
