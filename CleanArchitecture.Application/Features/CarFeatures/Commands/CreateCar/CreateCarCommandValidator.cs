using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(i => i.Brand).NotEmpty().WithMessage("Araç markası boş olamaz");
        RuleFor(i => i.Brand).NotNull().WithMessage("Araç markası boş olamaz");
        RuleFor(i => i.Brand).MinimumLength(3).WithMessage("Araç markası en az 3 karakter olmalı");

        RuleFor(i => i.Model).NotEmpty().WithMessage("Araç modeli boş olamaz");
        RuleFor(i => i.Model).NotNull().WithMessage("Araç modeli boş olamaz");
        RuleFor(i => i.Model).MinimumLength(3).WithMessage("Araç modeli en az 3 karakter olmalı");

        RuleFor(i => i.EnginePower).NotEmpty().WithMessage("Araç motor gücü boş olamaz");
        RuleFor(i => i.EnginePower).NotNull().WithMessage("Araç motor gücü boş olamaz");
        RuleFor(i => i.EnginePower).GreaterThan(0).WithMessage("Araç motor gücü 0'dan küçük olamaz");
    }
}
