using Lending_CapstoneProject.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lending_CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // FR3.4: Create a payment order for a specific loan application
        // POST: api/Payment/create-order
        [HttpPost("create-order/{loanApplicationId}")]
        public async Task<IActionResult> CreateOrder(int loanApplicationId)
        {
            // Fetch the amount to be paid from the loan record using the PaymentService
            decimal amount = await _paymentService.GetOutstandingAmountAsync(loanApplicationId);

            if (amount <= 0)
            {
                return NotFound("Loan application not found or has no outstanding balance.");
            }

            var order = await _paymentService.CreatePaymentOrderAsync(amount, loanApplicationId);
            if (order == null)
            {
                return NotFound("Failed to create payment order.");
            }
            return Ok(order);
        }

        // POST: api/Payment/webhook
        // This endpoint will be configured in the RazorPay dashboard
        [HttpPost("webhook")]
        public async Task<IActionResult> HandleWebhook()
        {
            using var reader = new StreamReader(Request.Body);
            var body = await reader.ReadToEndAsync();
            string signature = Request.Headers["X-Razorpay-Signature"];

            if (string.IsNullOrEmpty(signature))
            {
                return BadRequest("Signature header not found.");
            }

            await _paymentService.HandleWebhookAsync(body, signature);

            return Ok();
        }
    }
}
