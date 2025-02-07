using Application.Room.Models.Requests;
using Application.Room.Models.Responses;

namespace Application.Room.Ports;

public interface IRoomService
{
    Task<RoomResponse> CreateRoomAsync(CreateRoomRequest request);
}
