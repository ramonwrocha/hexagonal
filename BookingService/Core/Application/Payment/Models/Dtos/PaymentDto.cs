using Application.Payment.Models.Enums;

namespace Application.Payment.Models.Dtos;

public class PaymentDto
{
    public int BookingId { get; set; }

    public decimal Amount { get; set; }

    public PaymentProvider Provider { get; set; }
}