using Data.DataAccess;
using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence;

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

    public async Task<GuestEntity> GetByDocument(string documentNumber)
    {
        var result = await context.Guests
            .FirstOrDefaultAsync(g => g.Document.Number.ToUpper().Equals(documentNumber.ToUpper()));

        return result;
    }
}
