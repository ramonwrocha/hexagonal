using Application.Payment.Models.Requests;
using Application.Payment.Models.Responses;

namespace Application.Payment.Ports;

public interface IPaymentProcessorFactory
{
    Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request);
}
