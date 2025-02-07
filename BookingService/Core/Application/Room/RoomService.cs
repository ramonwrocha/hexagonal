using Application.Room.Models.Mappings;
using Application.Room.Models.Requests;
using Application.Room.Models.Responses;
using Application.Room.Ports;
using Domain.Ports;

namespace Application.Room;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    public async Task<RoomResponse> CreateRoomAsync(CreateRoomRequest request)
    {
        try
        {
            var model = RoomMapper.Map(request.Data);
            var id = await roomRepository.Create(model);

            var result = await roomRepository.Get(id);

            return new RoomResponse()
            {
                Data = RoomMapper.Map(result)
            };
        }
        catch (Exception e)
        {
            return new RoomResponse
            {
                Success = false,
                MessageError = e.Message
            };
        }
    }
}
