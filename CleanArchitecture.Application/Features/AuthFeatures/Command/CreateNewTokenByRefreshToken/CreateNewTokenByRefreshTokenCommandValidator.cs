using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Command.CreateNewTokenByRefreshToken
{
    public sealed class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
    {
        public CreateNewTokenByRefreshTokenCommandValidator()
        {
            RuleFor(i => i.UserId).NotEmpty().WithMessage("User bilgisi boş olamaz");
            RuleFor(i => i.UserId).NotNull().WithMessage("User bilgisi boş olamaz");
            RuleFor(i => i.RefreshToken).NotEmpty().WithMessage("Refresh Token bilgisi boş olamaz");
            RuleFor(i => i.RefreshToken).NotEmpty().WithMessage("Refresh Token bilgisi boş olamaz");
        }
    }
}
