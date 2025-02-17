﻿using Application.Payment.Models.Requests;
using Application.Payment.Models.Responses;

namespace Application.Payment.Ports.Base;

public interface IPaymentServiceBase
{
    Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request);
}