using Application.Payment.Models.Requests;
using Application.Payment.Models.Responses;
using Application.Payment.Ports;
using Domain.Ports;

namespace Application.Payment.Adapters;

public class PaymentService(IBookingRepository bookingRepository, IPaymentProcessorFactory paymentProcessorFactory) : IPaymentService
{
    public async Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
    {
        await ValidateAmountAsync(request);

        var response = await paymentProcessorFactory.CreatePaymentAsync(request);

        return response;
    }

    private async Task ValidateAmountAsync(CreatePaymentRequest request)
    {
        var booking = await bookingRepository.Get(id: request.Data.BookingId);
        if (booking.TotalPrice != request.Data.Amount)
        {
            throw new Exception("Invalid amount");
        }
    }
}
