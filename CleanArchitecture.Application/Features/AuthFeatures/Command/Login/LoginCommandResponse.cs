﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Command.Login
{
    public sealed record LoginCommandResponse(
        string Token,
        string RefreshToken,
        DateTime? RefreshTokenExpires,
        string UserId
        );
}
