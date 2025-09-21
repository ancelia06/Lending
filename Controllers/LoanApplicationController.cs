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
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoanApplicationService _loanApplicationService;

        public LoanApplicationController(ILoanApplicationService loanApplicationService)
        {
            _loanApplicationService = loanApplicationService;
        }

        // FR3.3: Apply for a loan by a customer
        // POST: api/LoanApplication
        [HttpPost]
        public async Task<IActionResult> ApplyForLoan([FromBody] LoanApplicationDto loanApplicationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newApplication = await _loanApplicationService.ApplyForLoanAsync(loanApplicationDto);
            return CreatedAtAction(nameof(GetApplicationDetails), new { loanApplicationId = newApplication.LoanApplicationId }, newApplication);
        }

        // FR2.2 & FR3.4: Get details of a specific loan application
        // This endpoint can be used by both the Customer and Loan Officer roles.
        // GET: api/LoanApplication/{loanApplicationId}
        [HttpGet("{loanApplicationId}")]
        public async Task<IActionResult> GetApplicationDetails(int loanApplicationId)
        {
            var application = await _loanApplicationService.GetLoanApplicationDetailsAsync(loanApplicationId);
            if (application == null)
            {
                return NotFound("Loan application not found.");
            }
            return Ok(application);
        }

        // FR2.1: View pending loan applications for a specific loan officer
        // This is an alternative/additional endpoint to be used by the LoanOfficerController
        [HttpGet("officer/{loanOfficerId}/pending")]
        public async Task<IActionResult> GetPendingApplicationsForOfficer(int loanOfficerId)
        {
            var pendingApplications = await _loanApplicationService.GetPendingApplicationsForOfficerAsync(loanOfficerId);
            return Ok(pendingApplications);
        }

    }
}
