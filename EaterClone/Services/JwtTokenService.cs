using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EaterClone.Domain;
using EaterClone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EaterClone.Services;

public class JwtTokenService(AppDbContext dbContext)
{
    public async Task<UserTokensDto> GenerateTokens(Guid userId)
    { 
        var user = await dbContext.UserEntities.FirstOrDefaultAsync(x => x.Id == userId);
        var accessToken = GenerateAccessToken(userId);
        var refreshToken = GenerateRefreshToken();
        
        return new UserTokensDto
        {
            UserId = user!.Id,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    private string GenerateAccessToken(Guid userId)
    {
        var claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, userId.ToString()) };
        var accessJwt = new JwtSecurityToken(
            issuer: null,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey("secret-key"u8.ToArray()),
                SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(accessJwt);
    }

    private string GenerateRefreshToken()
    {
        var refreshJwt = new JwtSecurityToken(
            issuer: null,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(2)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey("secret-key"u8.ToArray()),
                SecurityAlgorithms.HmacSha256)
        );
        
        return new JwtSecurityTokenHandler().WriteToken(refreshJwt);
    }

}