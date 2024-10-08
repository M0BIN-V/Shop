﻿using Application.Models.Auth;

namespace Application.Interfaces.Auth;

public interface IJwtService
{
    public string Generate(LoginClaims claims);
}
