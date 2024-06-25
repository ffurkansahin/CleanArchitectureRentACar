using CleanArchitecture.Application.Features.AuthFeatures.Command.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Command.CreateNewTokenByRefreshToken
{
    public sealed record CreateNewTokenByRefreshTokenCommand(
        string UserId,
        string RefreshToken) : IRequest<LoginCommandResponse>;
}
