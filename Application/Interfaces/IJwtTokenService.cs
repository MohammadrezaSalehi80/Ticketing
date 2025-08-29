using Application.DTOs.UserDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GeneratJwtToken(UserDto user);
    }
}
