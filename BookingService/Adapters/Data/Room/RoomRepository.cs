using Data.DataAccess;
using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Room;

public class RoomRepository(HotelBookingDbContext context) : IRoomRepository
{
    public async Task<RoomEntity> GetByName(string name)
    {
        var result = await context.Rooms
            .FirstOrDefaultAsync(g => g.Name.ToUpper().Equals(name.ToUpper()));

        return result;
    }

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
