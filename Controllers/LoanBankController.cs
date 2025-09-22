using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lending_CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanBankController : ControllerBase
    {
        private readonly ILoanBankService _loanBankService;

        public LoanBankController(ILoanBankService loanBankService)
        {
            _loanBankService = loanBankService;
        }

        // POST: api/LoanBank
        [HttpPost]
        public async Task<IActionResult> AddBank([FromBody] LoanBankDto bankDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBank = await _loanBankService.AddBankAsync(bankDto);
            return CreatedAtAction(nameof(GetBankById), new { id = newBank.BankId }, newBank);
        }

        // GET: api/LoanBank
        [HttpGet]
        public async Task<IActionResult> GetAllBanks()
        {
            var banks = await _loanBankService.GetAllBanksAsync();
            return Ok(banks);
        }

        // GET: api/LoanBank/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankById(int id)
        {
            var bank = await _loanBankService.GetBankByIdAsync(id);
            if (bank == null)
            {
                return NotFound("Loan bank not found.");
            }
            return Ok(bank);
        }

        // PUT: api/LoanBank/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBank(int id, [FromBody] LoanBankDto bankDto)
        {
            if (id != bankDto.BankId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _loanBankService.UpdateBankAsync(bankDto);
            if (!result)
            {
                return NotFound("Loan bank not found or update failed.");
            }
            return NoContent();
        }

        // DELETE: api/LoanBank/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            var result = await _loanBankService.DeleteBankAsync(id);
            if (!result)
            {
                return NotFound("Loan bank not found.");
            }
            return NoContent();
        }

    }
}
