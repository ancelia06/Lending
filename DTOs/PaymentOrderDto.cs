using System.Text.Json.Serialization;

namespace Lending_CapstoneProject.DTOs
{
    public class PaymentOrderDto
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("loanApplicationId")]
        public int LoanApplicationId { get; set; }
    }
}
