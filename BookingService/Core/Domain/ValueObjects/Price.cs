using Domain.Enums;

namespace Domain.ValueObjects;

public class Price
{
    public decimal Amount { get; set; }

    public Currency Currency { get; set; }
}
