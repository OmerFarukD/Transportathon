using FluentValidation;

namespace Application.Features.Car.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.Plate).NotEmpty().MinimumLength(6);
        RuleFor(x => x.CompanyId).NotEmpty();
        RuleFor(x => x.CarDetail).MinimumLength(10);
     //   RuleFor(x => x.CarType).NotEmpty();

    }
}