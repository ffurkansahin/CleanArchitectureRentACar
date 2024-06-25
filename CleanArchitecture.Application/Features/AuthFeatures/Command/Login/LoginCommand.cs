using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Command.Login
{
    public sealed record LoginCommand(
        string userNameOrEmail,
        string password) : IRequest<LoginCommandResponse>;
}
