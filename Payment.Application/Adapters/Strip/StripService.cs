using Application.Payment.Models.Requests;
using Application.Payment.Models.Responses;
using Application.Payment.Ports;

namespace Payment.Application.Adapters.Strip;

public class StripService : IPaymentService
{
    public Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
    {
        throw new NotImplementedException();
    }
}
