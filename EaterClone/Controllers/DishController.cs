using EaterClone.Models;
using EaterClone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EaterClone.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class DishController(DishService dishService) : ControllerBase
{
    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto>> GetDish(Guid dishId)
    {
        return await dishService.FindById(dishId);
    }

    [HttpPost]
    public async Task<ActionResult<DishDto>> CreateDish([FromBody] CreateDishDto dto)
    {
        return await dishService.Create(dto);
    }
    
}