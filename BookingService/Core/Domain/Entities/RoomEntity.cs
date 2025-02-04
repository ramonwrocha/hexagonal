using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class RoomEntity : EntityBase
{
    public string Name { get; set; }

    public int Capacity { get; set; }

    public decimal Price { get; set; }

    public RoomAvailability Availability { get; set; } = RoomAvailability.Available;
}
