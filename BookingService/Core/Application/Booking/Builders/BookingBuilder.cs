using Domain.Entities;

namespace Application.Booking.Builders;

public class BookingBuilder(BookingEntity _booking)
{
    private ICollection<BookingGuestEntity> _bookingGuests;

    public BookingBuilder WithBookingGuests(ICollection<GuestEntity> guests)
    {
        _bookingGuests = guests.Select(x => new BookingGuestEntity()
        {
            Booking = _booking,
            Guest = x,
        }).ToList();

        return this;
    }
    
    public BookingEntity Build(RoomEntity room)
    {
        return new BookingEntity
        {
            Id = _booking.Id,
            CheckIn = _booking.CheckIn,
            CheckOut = _booking.CheckOut,
            TotalPrice = CalculateTotalPrice(room),
            Room = room,
            BookingGuests = _bookingGuests
        };
    }

    private decimal CalculateTotalPrice(RoomEntity room)
    {
        var days = Math.Max((_booking.CheckOut - _booking.CheckIn).Days, 1);
        var totalPriceDays = room.Price.Amount * days;
        totalPriceDays *= _bookingGuests.Count;
        return totalPriceDays;
    }

}
