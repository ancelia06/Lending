using Lending_CapstoneProject.DTOs;

namespace Lending_CapstoneProject.Services.Interface
{
    public interface IPaymentService
    {
        Task<PaymentOrderDto> CreatePaymentOrderAsync(decimal amount, int loanApplicationId);
        Task<bool> HandleWebhookAsync(string body, string signature);

        // Add the missing method to resolve CS1061
        Task<decimal> GetOutstandingAmountAsync(int loanApplicationId);
    }
}
