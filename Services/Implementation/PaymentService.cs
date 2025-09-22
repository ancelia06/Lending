using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Services.Interface;
using Razorpay.Api;

namespace Lending_CapstoneProject.Services.Implementation
{
    public class PaymentService:IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepaymentService _repaymentService;
        private readonly string _razorpayKey;
        private readonly string _razorpaySecret;

        public PaymentService(IConfiguration configuration, IRepaymentService repaymentService)
        {
            _configuration = configuration;
            _repaymentService = repaymentService;

            _razorpayKey = _configuration["RazorPay:KeyId"];
            _razorpaySecret = _configuration["RazorPay:KeySecret"];
        }

        public async Task<PaymentOrderDto> CreatePaymentOrderAsync(decimal amount, int loanApplicationId)
        {
            var client = new RazorpayClient(_razorpayKey, _razorpaySecret);

            var options = new Dictionary<string, object>
            {
                { "amount", (int)(amount * 100) }, // amount in paisa
                { "currency", "INR" },
                { "receipt", $"loan_app_{loanApplicationId}_repayment" }
            };

            var order = client.Order.Create(options);

            return new PaymentOrderDto
            {
                OrderId = order["id"],
                Amount = amount,
                Currency = "INR",
                LoanApplicationId = loanApplicationId
            };
        }

        public async Task<bool> HandleWebhookAsync(string body, string signature)
        {
            // First, verify the signature to ensure the webhook is from RazorPay
            try
            {
                Utils.verifyWebhookSignature(body, signature, _razorpaySecret);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Webhook signature verification failed: {ex.Message}");
                return false;
            }

            // The webhook body contains the full payment details
            var paymentData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(body);
            var payment = paymentData.payload.payment.entity;

            // Use the verified payment data to record the repayment in our application
            var repaymentDto = new RepaymentDto
            {
                LoanApplicationId = int.Parse(payment.notes.loan_application_id.ToString()),
                Amount = decimal.Parse(payment.amount.ToString()) / 100, // Convert paisa back to decimal
                TransactionId = payment.id.ToString()
            };

            await _repaymentService.RecordRepaymentAsync(repaymentDto);

            return true;
        }
        public async Task<decimal> GetOutstandingAmountAsync(int loanApplicationId)
        {
            // Placeholder logic for calculating outstanding amount
            // Replace this with actual logic to fetch and calculate the outstanding amount
            decimal outstandingAmount = 1000.00m; // Example value
            return await Task.FromResult(outstandingAmount);
        }
    }
}
