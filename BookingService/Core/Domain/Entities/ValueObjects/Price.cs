using Domain.Entities.Enums;

namespace Domain.Entities.ValueObjects;

public sealed class Price
{
    public decimal Amount { get; set; }

    public Currency Currency { get; set; }
}
