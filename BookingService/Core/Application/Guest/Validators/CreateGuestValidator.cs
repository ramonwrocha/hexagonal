using Application.Guest.Models.Requests;
using FluentValidation;

namespace Application.Guest.Validators;

public class CreateGuestValidator : AbstractValidator<CreateGuestRequest>
{
    public CreateGuestValidator()
    {
        RuleFor(x => x.Data.Email).NotNull().NotEmpty();
        RuleFor(x => x.Data.Name).NotNull().NotEmpty();
        RuleFor(x => x.Data.Surname).NotNull().NotEmpty();
        RuleFor(x => x.Data.DocumentNumber).NotNull().NotEmpty();
    }
}
