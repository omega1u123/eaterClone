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

    [HttpPost("signUp")]
    public async Task<ActionResult<SignUpResponse>> SignUp(SignUpRequest signUpRequest)
    {
        return  await userService.SingUp(signUpRequest);
    }

    [HttpPost("signIn")]
    public async Task<ActionResult<SignInResponse>> SignIn(SignInRequest signInRequest)
    {
        return await userService.SignIn(signInRequest);
    }
    
}