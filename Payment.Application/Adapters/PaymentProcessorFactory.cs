using Application.Payment.Models.Enums;
using Application.Payment.Models.Requests;
using Application.Payment.Models.Responses;
using Application.Payment.Ports;
using Microsoft.Extensions.Options;
using Payment.Application.Adapters.PayPal;

namespace Payment.Application.Adapters;

public class PaymentProcessorFactory(IOptions<PayPalConfiguration> payPalOptions) : IPaymentProcessorFactory
{
    public Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
    {
        var service = request.Data.Provider switch
        {
            PaymentProvider.PayPal => new PayPalService(payPalOptions),
            PaymentProvider.Stripe => throw new NotImplementedException(),
            _ => throw new Exception("Invalid payment provider")
        };

        return service.CreatePaymentAsync(request);
    }
}
