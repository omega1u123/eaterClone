using EaterClone.Domain.Entities;
using EaterClone.Domain.Repository;
using EaterClone.Models;

namespace EaterClone.Services;

public class DishService(DishRepository dishRepository)
{
    public async Task<DishDto> Create(CreateDishDto createDishDto)
    {
        var dish = new DishEntity
        {
            Name = createDishDto.Name,
            Weight = createDishDto.Weight,
            Products = createDishDto.ProductsId,
            PictureUrl = createDishDto.PictureUrl,
            UserId = createDishDto.UserId
        };

        await dishRepository.Create(dish);

        return new DishDto
        {
            Id = dish.Id,
            Name = dish.Name,
            Weight = dish.Weight,
            ProductsId = dish.Products,
            PictureUrl = dish.PictureUrl,
            UserId = dish.UserId
        };
    }

    public async Task<List<DishDto>> FindAllByUserId(Guid userId)
    {
        var dishes = await dishRepository.FindAllByUserId(userId);

        return dishes.Select(x =>
            new DishDto
            {
                Id = x.Id,
                Name = x.Name,
                Weight = x.Weight,
                ProductsId = x.Products,
                PictureUrl = x.PictureUrl,
                UserId = x.UserId
            }).ToList();
    }
    
}