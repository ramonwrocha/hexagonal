using Application.Payment.Models.Dtos;
using Application.Payment.Models.Requests;
using Application.Payment.Models.Responses;
using Application.Payment.Ports;
using Braintree;
using Microsoft.Extensions.Options;

namespace Payment.Application.Adapters.PayPal;

public class PayPalService : IPaymentService
{
    private readonly PayPalConfiguration _options;

    private readonly IBraintreeGateway _gateway;

    public PayPalService(IOptions<PayPalConfiguration> options)
    {
        _options = options.Value;

        var environment = _options.Environment;
        var merchantId = _options.MerchantID;
        var publicKey = _options.PublicKey;
        var privateKey = _options.PrivateKey;

        _gateway = new BraintreeGateway(environment, merchantId, publicKey, privateKey);
    }

    public async Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
    {
        var clientToken = await _gateway.ClientToken.GenerateAsync();

        return new CreatePaymentResponse
        {
            Data = new PaymentDto
            {
                Amount = request.Data.Amount,
                Provider = request.Data.Provider
            },
            ClientToken = clientToken
        };
    }
}
