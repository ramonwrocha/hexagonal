using Domain.Entities.Enums;

namespace Application.Room.Models.Dtos;

public sealed record RoomDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Capacity { get; set; }

    public RoomAvailability Availability { get; set; } = RoomAvailability.Available;

    public decimal PriceAmount { get; set; }

    public Currency PriceCurrency { get; set; }
}
