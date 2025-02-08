using Application.Booking.Models.Requests;
using Application.Booking.Mappings;
using Application.Booking.Models.Responses;
using Application.Booking.Ports;
using Domain.Entities;
using Domain.Ports;
using Application.Booking.Validators;

namespace Application.Booking;

public class BookingService(IBookingRepository bookingRepository, IGuestRepository guestRepository, IRoomRepository roomRepository) : IBookingService
{
    public async Task<BookingResponse> CreateBookingAsync(CreateBookingRequest request)
    {
        try
        {
            await CreateBookingRequestValidate(request);
            
            var room = await GetRoomAsync(request.Data.RoomName);

            var guests = await GetGuestAsync(request.Data.GuestDocuments);
            
            var booking = BookingMapper.Map(request.Data, room, guests);

            booking.TotalPrice = CalculateTotalPrice(booking, room);

            var id = await bookingRepository.Create(booking);

            var result = await bookingRepository.Get(id);

            return new BookingResponse()
            {
                Data = BookingMapper.Map(result)
            };
        }
        catch (Exception e)
        {
            return new BookingResponse
            {
                Success = false,
                MessageError = e.Message
            };
        }
    }

    private async Task CreateBookingRequestValidate(CreateBookingRequest request)
    {
        var validator = new CreateBookingValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new Exception(validationResult.ToString());
        }
    }

    private async Task<ICollection<GuestEntity>> GetGuestAsync(ICollection<string> guestDocuments)
    {
        var guests = new List<GuestEntity>();
        foreach (var document in guestDocuments)
        {
            var guestEntity = await guestRepository.GetByDocument(document);
            guests.Add(guestEntity);
        }

        return guests;
    }

    private async Task<RoomEntity> GetRoomAsync(string roomName)
    {
        var room = await roomRepository.GetByName(roomName);
        if (room is null)
        {
            throw new Exception("Room not found");
        }

        return room;
    }
    
    private static decimal CalculateTotalPrice(BookingEntity booking, RoomEntity room)
    {
        var totalPriceDays = room.Price.Amount * (booking.CheckOut - booking.CheckIn).Days;
        totalPriceDays *= booking.Guests.Count;
        return totalPriceDays;
    }
}
