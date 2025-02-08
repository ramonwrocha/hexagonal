using Application.Guest.Models.Requests;
using Application.Guest.Models.Responses;

namespace Application.Guest.Ports;

public interface IGuestService
{
    Task<GuestResponse> CreateGuestAsync(CreateGuestRequest request);
}
