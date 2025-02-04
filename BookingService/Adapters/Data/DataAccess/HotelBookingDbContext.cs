using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccess;

public class HotelBookingDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<RoomEntity> Rooms { get; set; }

    public DbSet<GuestEntity> Guests { get; set; }

    public DbSet<BookingEntity> Bookings { get; set; }
}
