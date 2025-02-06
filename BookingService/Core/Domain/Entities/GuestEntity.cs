using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class GuestEntity : EntityBase
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public GuestType Type { get; set; }

    public DocumentNumber Document { get; set; }
}
