using Application.Payment.Models.Requests;
using Application.Payment.Models.Responses;

namespace Application.Payment.Ports;

public interface IPaymentService
{
    Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request);
}