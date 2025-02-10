using Domain.Entities.Base;
using Domain.Entities.Enums;
using Domain.Entities.ValueObjects;

namespace Domain.Entities;

public class RoomEntity : EntityBase
{
    public string Name { get; set; }

    public int Capacity { get; set; }
    
    public RoomAvailability Availability { get; set; } = RoomAvailability.Available;

    public Price Price { get; set; }
}
