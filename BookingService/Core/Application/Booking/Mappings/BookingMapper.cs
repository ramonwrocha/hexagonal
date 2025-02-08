using Application.Booking.Models.DTOs;
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
            GuestDocuments = entity.Guests.Select(x => x.Document.Number).ToList()
        };
    }

    public static BookingEntity Map(BookingDto dto, RoomEntity room, ICollection<GuestEntity> guests)
    {
        return new BookingEntity()
        {
            Id = dto.Id,
            CheckIn = dto.CheckIn,
            CheckOut = dto.CheckOut,
            TotalPrice = dto.TotalPrice,
            Room = room,
            Guests = guests
        };
    }
}
