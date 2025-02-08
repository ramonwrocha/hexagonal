using Application.Room.Models.Requests;
using FluentValidation;

namespace Application.Room.Validators;

public class CreateRoomValidators : AbstractValidator<CreateRoomRequest>
{
    public CreateRoomValidators()
    {
        RuleFor(x => x.Data.Name).NotNull().NotEmpty();

        RuleFor(x => x.Data.Capacity).NotNull().NotEmpty();

        RuleFor(x => x.Data.PriceCurrency).NotNull().NotEmpty();
        
        RuleFor(x => x.Data.PriceAmount).NotNull().NotEmpty();
    }
}
