using Application.Booking.Models.Dtos;
using Domain.Entities;

namespace Application.Booking.Mappings;

public static class BookingMapper
{ 
    public static BookingDto Map(BookingEntity entity)
    {
        return new BookingDto()
        {
            Id = entity.Id,
            CheckIn = entity.CheckIn,
            CheckOut = entity.CheckOut,
            TotalPrice = entity.TotalPrice,
            RoomName = entity.Room.Name,
            GuestDocuments = entity.BookingGuests.Select(x => x.Guest.Document.Number).ToList()
        };
    }

    public static BookingEntity Map(BookingDto dto)
    {
        return new BookingEntity()
        {
            Id = dto.Id,
            CheckIn = dto.CheckIn,
            CheckOut = dto.CheckOut,
            TotalPrice = dto.TotalPrice,
            Room = null,
            BookingGuests = new HashSet<BookingGuestEntity>()
        };
    }
}
