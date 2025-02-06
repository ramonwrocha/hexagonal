using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class RoomEntity : EntityBase
{
    public string Name { get; set; }

    public int Capacity { get; set; }
    
    public RoomAvailability Availability { get; set; } = RoomAvailability.Available;

    public Price Price { get; set; }
}
