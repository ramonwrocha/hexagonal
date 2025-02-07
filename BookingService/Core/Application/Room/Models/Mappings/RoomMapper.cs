using Application.Room.Models.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Room.Models.Mappings;

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
