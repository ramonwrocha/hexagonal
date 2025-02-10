using Application.Booking.Models.Requests;
using FluentValidation;

namespace Application.Booking.Validators;

public class CreateBookingValidator : AbstractValidator<CreateBookingRequest>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.Data.RoomName).NotNull().NotEmpty();

        RuleFor(x => x.Data.GuestDocuments).NotNull().NotEmpty();

        RuleFor(x => x.Data.GuestDocuments).Must(x => x.Count > 0);

        RuleFor(x => x.Data.GuestDocuments).Must(x => x.Count <= 4);

        RuleFor(x => x.Data.CheckIn)
            .NotNull()
            .NotEmpty()
            .LessThan(x => x.Data.CheckOut);
    }
}
