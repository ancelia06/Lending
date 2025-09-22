//using Lending_CapstoneProject.Models;
//using Lending_CapstoneProject.Services.Interface;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace Lending_CapstoneProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoanCompanyController : ControllerBase
//    {
//        private readonly ILoanCompanyService _service;

//        public LoanCompanyController(ILoanCompanyService service)
//        {
//            _service = service;
//        }

//        // GET: api/LoanCompany
//        [HttpGet]
//        public async Task<ActionResult<LoanBank>> Get()
//        {
//            var company = await _service.GetAsync();
//            if (company == null)
//                return NotFound("No loan company found.");

//            return Ok(company);
//        }

//        // POST: api/LoanCompany
//        [HttpPost]
//        public async Task<ActionResult> Add([FromBody] LoanBank company)
//        {
//            await _service.AddAsync(company);
//            return Ok("Loan company added successfully.");
//        }

//        // PUT: api/LoanCompany
//        [HttpPut]
//        public async Task<ActionResult> Update([FromBody] LoanBank company)
//        {
//            var existing = await _service.GetAsync();
//            if (existing == null)
//                return NotFound("No loan company found to update.");

//            await _service.UpdateAsync(company);
//            return NoContent();
//        }

//        // DELETE: api/LoanCompany
//        [HttpDelete]
//        public async Task<ActionResult> Delete()
//        {
//            var deleted = await _service.DeleteAsync(0); // ID parameter is unused in your repo
//            if (!deleted)
//                return NotFound("No loan company found to delete.");

//            return NoContent();
//        }
//    }
//}
