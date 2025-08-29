using Application.DTOs.UserDtos;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Implementations
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GeneratJwtToken(UserDto user)
        {
            var jwtSettings = _configuration.GetSection("JwtSetting");

            var claim = new List<Claim>();
            claim.Add(new Claim(ClaimTypes.Email, user.Email));
            claim.Add(new Claim(ClaimTypes.Role, user.Role));
            claim.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claim,
                    expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpirMinute"])),
                    signingCredentials: cred

                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
