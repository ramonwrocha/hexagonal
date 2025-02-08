using Application.Booking.Models.Requests;
using Application.Booking.Models.Responses;
using Application.Booking.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController(IBookingService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<BookingResponse>> CreateBooking([FromBody] CreateBookingRequest request)
    {
        var response = await service.CreateBookingAsync(request);

        if (response.Success)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
}