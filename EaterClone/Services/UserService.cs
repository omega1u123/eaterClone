using EaterClone.Domain.Repository;
using EaterClone.Models;

namespace EaterClone.Services;

public class UserService(UserRepository userRepository)
{
    public async Task<UserDto> FindById(Guid userId)
    {
        var user = await userRepository.FindById(userId);
        if (user == null)
        {
            throw new NotImplementedException("Not implemented");
        }
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name
        };
    }
    
}