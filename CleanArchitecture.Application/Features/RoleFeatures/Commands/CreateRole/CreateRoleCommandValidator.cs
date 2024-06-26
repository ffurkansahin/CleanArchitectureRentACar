using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("İsim kısmı boş olamaz");
            RuleFor(i => i.Name).NotNull().WithMessage("İsim kısmı boş olamaz");
        }
    }
}
