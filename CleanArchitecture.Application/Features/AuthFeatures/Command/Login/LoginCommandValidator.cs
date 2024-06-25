using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Command.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(i => i.password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(i => i.password).NotNull().WithMessage("Şifre boş olamaz");
            RuleFor(i => i.password).Matches("[A-Z]").WithMessage("Şifre en az bir adet büyük harf içermelidir");
            RuleFor(i => i.password).Matches("[a-z]").WithMessage("Şifre en az bir adet küçük harf içermelidir");
            RuleFor(i => i.password).Matches("[0-9]").WithMessage("Şifre en az bir adet rakam içermelidir");
            RuleFor(i => i.password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir");

            RuleFor(i => i.userNameOrEmail).NotNull().WithMessage("Kullanıcı adı veya mail bilgisi boş olamaz");
            RuleFor(i => i.userNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı veya mail bilgisi boş olamaz");
            RuleFor(i => i.userNameOrEmail).MinimumLength(3).WithMessage("Kullanıcı adı veya mail bilgisi en az 3 karakterden oluşmalı");
        }
    }
}
