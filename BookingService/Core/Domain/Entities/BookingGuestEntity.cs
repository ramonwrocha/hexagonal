namespace Domain.Entities;

//Junction table for many-to-many relationship between Booking and Guest
public class BookingGuestEntity
{
    public int GuestId { get; set; }

    public GuestEntity Guest { get; set; }

    public int BookingId { get; set; }

    public BookingEntity Booking { get; set; }
}
