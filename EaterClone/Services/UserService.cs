using EaterClone.Domain.Entities;
using EaterClone.Domain.Repository;
using EaterClone.Models;

namespace EaterClone.Services;

public class UserService(UserRepository userRepository)
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

    public async Task<UserDto> SingUp(SignUpRequest signUpRequest)
    {
        var user = new UserEntity
        {
            Name = signUpRequest.Name,
            Password = signUpRequest.Password
        };
        
        await userRepository.Create(user);

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name
        };
    }

    public async Task<UserDto> SignIn(SignInRequest signInRequest)
    {
        var user = await userRepository.FindByNameAndPassword(signInRequest.Name, signInRequest.Password);
        if (user is null)
            throw new NotImplementedException("SignIn exception");

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name
        };
    }
    
}