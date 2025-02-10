using Application.Guest.Mappings;
using Application.Guest.Models.Requests;
using Application.Guest.Models.Responses;
using Application.Guest.Ports;
using Domain.Ports;

namespace Application.Guest.Adapters;

public class GuestService(IGuestRepository guestRepository) : IGuestService
{
    public async Task<GuestResponse> CreateGuestAsync(CreateGuestRequest request)
    {
        try
        {
            var model = GuestMapper.Map(request.Data);
            var id = await guestRepository.Create(model);

            var result = await guestRepository.Get(id);

            return new GuestResponse()
            {
                Data = GuestMapper.Map(result)
            };
        }
        catch (Exception e)
        {
            return new GuestResponse
            {
                Success = false,
                MessageError = e.Message
            };
        }
    }
}
