using Domain.Enums;

namespace Domain.ValueObjects;

public sealed class Price
{
    public decimal Amount { get; set; }

    public Currency Currency { get; set; }
}
