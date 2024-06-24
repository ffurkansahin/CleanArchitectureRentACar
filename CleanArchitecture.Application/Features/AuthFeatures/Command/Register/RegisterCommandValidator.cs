using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Command.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(i => i.Email).NotEmpty().WithMessage("Mail bilgisi boş olamaz");
            RuleFor(i => i.Email).NotNull().WithMessage("Mail bilgisi boş olamaz");
            RuleFor(i => i.Email).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");

            RuleFor(i => i.UserName).NotNull().WithMessage("Kullanıcı adı bilgisi boş olamaz");
            RuleFor(i => i.UserName).NotEmpty().WithMessage("Kullanıcı adı bilgisi boş olamaz");
            RuleFor(i => i.UserName).MinimumLength(3).WithMessage("Kullanıcı adı bilgisi en az 3 karakterden oluşmalı");

            RuleFor(i => i.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(i => i.Password).NotNull().WithMessage("Şifre boş olamaz");
            RuleFor(i => i.Password).Matches("[A-Z]").WithMessage("Şifre en az bir adet büyük harf içermelidir");
            RuleFor(i => i.Password).Matches("[a-z]").WithMessage("Şifre en az bir adet küçük harf içermelidir");
            RuleFor(i => i.Password).Matches("[0-9]").WithMessage("Şifre en az bir adet rakam içermelidir");
            RuleFor(i => i.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir");
        }
    }
}
