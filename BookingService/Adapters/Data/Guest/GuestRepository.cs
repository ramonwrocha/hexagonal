using Data.DataAccess;
using Domain.Entities;
using Domain.Ports;

namespace Data.Guest;

public class GuestRepository(HotelBookingDbContext context) : IGuestRepository
{
    public async Task<GuestEntity> Get(int id)
    {
        var result = await context.Guests.FindAsync(id);
        return result;
    }

    public async Task<int> Create(GuestEntity guest)
    {
        var result = await context.Guests.AddAsync(guest);
        await context.SaveChangesAsync();
        return result.Entity.Id;
    }
}
