using EaterClone.Domain;
using EaterClone.Domain.Entities;
using EaterClone.Domain.Repository;
using EaterClone.Models;

namespace EaterClone.Services;

public class UserService(AppDbContext appDbContext, UserRepository userRepository, JwtTokenService jwtTokenService)
{
    public async Task<UserDto> FindById(Guid userId)
    {
        var user = await userRepository.FindById(userId);
        
        if (user == null)
            throw new NotImplementedException("Not implemented");
        
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name
        };
    }

    public async Task<SignUpResponse> SingUp(SignUpRequest signUpRequest)
    {
        var user = new UserEntity
        {
            Name = signUpRequest.Name,
            Password = signUpRequest.Password
        };
        
        await userRepository.Create(user);
        
        var tokens = await jwtTokenService.GenerateTokens(user.Id);

        var jwtTokens = new JwtTokensEntity
        {
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken
        };
        
        await appDbContext.JwtTokensEntities.AddAsync(jwtTokens);
        await appDbContext.SaveChangesAsync();
        
        return new SignUpResponse
        {
            UserId = user.Id,
            Name = user.Name,
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken
        };
    }

    public async Task<SignInResponse> SignIn(SignInRequest signInRequest)
    {
        var user = await userRepository.FindByNameAndPassword(signInRequest.Name, signInRequest.Password);
        if (user is null)
            throw new NotImplementedException("SignIn exception");
        
        var tokens = await jwtTokenService.GenerateTokens(user.Id);
        
        var jwtTokens = new JwtTokensEntity
        {
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken
        };
        
        await appDbContext.JwtTokensEntities.AddAsync(jwtTokens);
        await appDbContext.SaveChangesAsync();

        
        return new SignInResponse
        {
            UserId = user.Id,
            Name = user.Name,
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken
        };
    }
    
}