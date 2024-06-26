using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.UserRoleFeature.Commands.CreateUserRole
{
    public sealed class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            RuleFor(i => i.RoleId).NotEmpty().WithMessage("Role Id boş olamaz");
            RuleFor(i => i.RoleId).NotNull().WithMessage("Role Id boş olamaz");
            RuleFor(i => i.UserId).NotEmpty().WithMessage("User Id boş olamaz");
            RuleFor(i => i.UserId).NotNull().WithMessage("User Id boş olamaz");
        }
    }
}
