using Application.Base;
using Application.Payment.Models.Dtos;

namespace Application.Payment.Models.Responses;

public class CreatePaymentResponse : ResponseBase<PaymentDto>
{
    public required string ClientToken { get; set; }
}
