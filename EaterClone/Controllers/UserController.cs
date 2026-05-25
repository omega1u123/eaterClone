using EaterClone.Models;
using EaterClone.Services;
using Microsoft.AspNetCore.Mvc;

namespace EaterClone.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserService userService, JwtTokenService jwtTokenService) : ControllerBase
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDto>> GetUserById(Guid userId)
    {
        return await userService.FindById(userId);
    }
    
}