﻿using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entites;

public sealed class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
}
