using CleanArchitecture.Application.Features.AuthFeatures.Command.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Command.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Command.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public  interface IAuthService
    {
        Task RegisterAsync(RegisterCommand request);
        Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
        Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken);

    }
}
