using Application.Booking.Models.Requests;
using Application.Booking.Models.Responses;

namespace Application.Booking.Ports;

public interface IBookingService
{
    Task<BookingResponse> CreateBookingAsync(CreateBookingRequest request);
}
