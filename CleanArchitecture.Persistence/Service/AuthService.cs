using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Command.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;
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

        public AuthService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task RegisterAsync(RegisterCommand request)
        {
            AppUser user = _mapper.Map<AppUser>(request);
            IdentityResult result = await _userManager.CreateAsync(user,request.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
    }
}
