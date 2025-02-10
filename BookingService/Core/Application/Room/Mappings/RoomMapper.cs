using Application.Room.Models.Dtos;
using Domain.Entities;
using Domain.Entities.ValueObjects;

namespace Application.Room.Mappings;

public static class RoomMapper
{
    public static RoomDto Map(RoomEntity entity)
    {
        return new RoomDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Capacity = entity.Capacity,
            Availability = entity.Availability,
            PriceAmount = entity.Price.Amount,
            PriceCurrency = entity.Price.Currency
        };
    }

    public static RoomEntity Map(RoomDto dto)
    {
        return new RoomEntity()
        {
            Id = dto.Id,
            Name = dto.Name,
            Capacity = dto.Capacity,
            Availability = dto.Availability,
            Price = new Price()
            {
                Amount = dto.PriceAmount,
                Currency = dto.PriceCurrency
            }
        };
    }
}
