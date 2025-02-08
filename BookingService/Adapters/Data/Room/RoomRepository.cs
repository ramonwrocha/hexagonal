using Data.DataAccess;
using Domain.Entities;
using Domain.Ports;

namespace Data.Room;

public class RoomRepository(HotelBookingDbContext context) : IRoomRepository
{
    public async Task<int> Create(RoomEntity room)
    {
        var result = await context.Rooms.AddAsync(room);
        await context.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<RoomEntity> Get(int id)
    {
        var result = await context.Rooms.FindAsync(id);
        return result;
    }
}
