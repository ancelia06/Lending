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
    public class RepaymentController : ControllerBase
    {
        private readonly IRepaymentService _repaymentService;

        public RepaymentController(IRepaymentService repaymentService)
        {
            _repaymentService = repaymentService;
        }

        // FR3.4: Endpoint for a customer to make a repayment
        // POST: api/Repayment
        [HttpPost]
        public async Task<IActionResult> MakeRepayment([FromBody] RepaymentDto repaymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repaymentService.MakeRepaymentAsync(repaymentDto);
            if (result == null)
            {
                return BadRequest("Failed to process repayment. Please check the loan application ID.");
            }

            return CreatedAtAction(nameof(GetRepaymentById), new { repaymentId = result.RepaymentId }, result);
        }

        // FR3.4: Endpoint for a customer to view their repayment history
        // GET: api/Repayment/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetRepaymentHistoryForCustomer(int customerId)
        {
            var history = await _repaymentService.GetRepaymentHistoryForCustomerAsync(customerId);
            return Ok(history);
        }

        // GET: api/Repayment/{repaymentId}
        [HttpGet("{repaymentId}")]
        public async Task<IActionResult> GetRepaymentById(int repaymentId)
        {
            var repayment = await _repaymentService.GetRepaymentByIdAsync(repaymentId);
            if (repayment == null)
            {
                return NotFound("Repayment not found.");
            }
            return Ok(repayment);
        }

    }
}
