//using Lending_CapstoneProject.Models;
//using Lending_CapstoneProject.Repositories.Interface;
//using Lending_CapstoneProject.Services.Interface;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Lending_CapstoneProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SystemController : ControllerBase
//    {
//        private readonly ISystemRepository _repository;

//        public SystemController(ISystemRepository repository)
//        {
//            _repository = repository;
//        }

//        // GET: api/System/customers/count
//        [HttpGet("customers/count")]
//        public async Task<ActionResult<int>> GetCustomerCount()
//        {
//            var count = await _repository.GetCustomerCountAsync();
//            return Ok(count);
//        }

//        // GET: api/System/officers/count
//        [HttpGet("officers/count")]
//        public async Task<ActionResult<int>> GetLoanOfficerCount()
//        {
//            var count = await _repository.GetLoanOfficerCountAsync();
//            return Ok(count);
//        }

//        // GET: api/System/applications/status-count
//        [HttpGet("applications/status-count")]
//        public async Task<ActionResult<Dictionary<ApplicationStatus, int>>> GetApplicationStatusCounts()
//        {
//            var counts = await _repository.GetApplicationStatusCountsAsync();
//            return Ok(counts);
//        }

//        // GET: api/System/applications/report
//        [HttpGet("applications/report")]
//        public async Task<ActionResult<IEnumerable<LoanApplication>>> GetLoanApplicationReport()
//        {
//            var report = await _repository.GetLoanApplicationReportAsync();
//            return Ok(report);
//        }

//        // GET: api/System/loans/disbursed/count
//        [HttpGet("loans/disbursed/count")]
//        public async Task<ActionResult<int>> GetDisbursedLoanCount()
//        {
//            var count = await _repository.GetDisbursedLoanCountAsync();
//            return Ok(count);
//        }

//        // GET: api/System/loans/disbursed/total
//        [HttpGet("loans/disbursed/total")]
//        public async Task<ActionResult<decimal>> GetTotalDisbursedAmount()
//        {
//            var total = await _repository.GetTotalDisbursedAmountAsync();
//            return Ok(total);
//        }

//        // GET: api/System/loans/repaid/count
//        [HttpGet("loans/repaid/count")]
//        public async Task<ActionResult<int>> GetRepaidLoanCount()
//        {
//            var count = await _repository.GetRepaidLoanCountAsync();
//            return Ok(count);
//        }
//    }
//}
