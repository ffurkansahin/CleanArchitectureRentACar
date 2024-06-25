using CleanArchitecture.Application.Features.AuthFeatures.Command.Login;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Abstractions;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(AppUser user);
}
