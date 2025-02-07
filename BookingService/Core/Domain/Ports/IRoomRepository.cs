using Domain.Entities;

namespace Domain.Ports;

public interface IRoomRepository
{
    Task<RoomEntity> Get(int id);

    Task<int> Create(RoomEntity guest);
}
