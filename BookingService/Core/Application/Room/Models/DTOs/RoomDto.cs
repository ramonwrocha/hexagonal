using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Room.Models.DTOs;

public class RoomDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Capacity { get; set; }

    public RoomAvailability Availability { get; set; } = RoomAvailability.Available;

    public decimal PriceAmount { get; set; }

    public Currency PriceCurrency { get; set; }
}
