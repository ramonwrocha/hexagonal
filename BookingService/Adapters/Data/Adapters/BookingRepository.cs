using Data.DataAccess;
using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence;

public class BookingRepository(HotelBookingDbContext context) : IBookingRepository
{
    public async Task<int> Create(BookingEntity guest)
    {
        var result = await context.Bookings.AddAsync(guest);
        await context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<BookingEntity> Get(int id)
    {
        var result = await context.Bookings.FindAsync(id);
        return result;
    }

    public Task<ICollection<BookingEntity>> GetByDocument(string email)
    {
        throw new NotImplementedException();
    }
}
