namespace Domain.Enums;

public enum BookingAction
{
    Pay = 0,
    Cancel = 1, // before paid
    Refund = 2, // after paid
    Reopen = 3 // after cancelled
}
