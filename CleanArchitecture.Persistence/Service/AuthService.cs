using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Command.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Command.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Command.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Service
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı");
            if (user.RefreshToken != request.RefreshToken)
                throw new Exception("Refresh Token geçerli değil");
            if (user.RefreshTokenExpires < DateTime.Now)
                throw new Exception("Refresh tokenın süresi dolmuş");
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.Users
                .Where(i => i.UserName == request.userNameOrEmail
                || i.Email == request.userNameOrEmail)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null) throw new Exception("Kullanıcı bulunamadı");

            var result = await _userManager.CheckPasswordAsync(user, request.password);
            if (result)
            {
                LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
                return response;
            }
            throw new Exception("Kullanıcı şifresi yanlış");
        }

        public async Task RegisterAsync(RegisterCommand request)
        {
            AppUser user = _mapper.Map<AppUser>(request);
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            List<string> emails = new List<string>();
            emails.Add(request.Email);
            string body = request.UserName + "kullanıcı adına sahip yeni hesabınız oluşturulmuştur";
            await _mailService.SendMailAsync(emails, "Mail Onayı", body);
        }
    }
}
