using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lending_CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanOfficerController : ControllerBase
    {
        private readonly ILoanOfficerService _loanOfficerService;

        public LoanOfficerController(ILoanOfficerService loanOfficerService)
        {
            _loanOfficerService = loanOfficerService;
        }

        // FR2.1: View all pending loan applications assigned to the officer
        // GET: api/LoanOfficer/applications/pending/{loanOfficerId}
        [HttpGet("applications/pending/{loanOfficerId}")]
        public async Task<IActionResult> GetPendingApplications(int loanOfficerId)
        {
            var applications = await _loanOfficerService.GetPendingApplicationsAsync(loanOfficerId);
            return Ok(applications);
        }

        // FR2.2: Get a specific loan application's details
        // GET: api/LoanOfficer/applications/{loanApplicationId}
        [HttpGet("applications/{loanApplicationId}")]
        public async Task<IActionResult> GetApplicationDetails(int loanApplicationId)
        {
            var application = await _loanOfficerService.GetApplicationDetailsAsync(loanApplicationId);
            if (application == null)
            {
                return NotFound("Loan application not found.");
            }
            return Ok(application);
        }

        // FR2.3: Approve or reject a loan application
        // PUT: api/LoanOfficer/applications/{loanApplicationId}/status
        [HttpPut("applications/{loanApplicationId}/status")]
        public async Task<IActionResult> UpdateLoanApplicationStatus(int loanApplicationId, [FromBody] LoanApplicationStatusUpdateDto statusUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _loanOfficerService.UpdateLoanApplicationStatusAsync(loanApplicationId, statusUpdateDto);
            if (!result)
            {
                return BadRequest("Failed to update loan application status. Check if the application exists or if the loan officer has permission.");
            }

            return NoContent(); // 204 No Content is a common response for a successful PUT/UPDATE
        }

        // FR2.4: Handle customer queries
        // This is a placeholder as the SRS does not specify the implementation details.
        // It would likely involve a separate service for messaging or email.
        [HttpPost("customer-query/{customerId}")]
        public async Task<IActionResult> RespondToCustomerQuery(int customerId, [FromBody] string message)
        {
            var result = await _loanOfficerService.RespondToCustomerQueryAsync(customerId, message);
            if (!result)
            {
                return BadRequest("Failed to send a response to the customer.");
            }
            return Ok("Response sent successfully.");
        }

    }
}
