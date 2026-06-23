using EaterClone.Domain;
using EaterClone.Domain.Entities;
using EaterClone.Domain.Repository;
using EaterClone.Models;
using Microsoft.EntityFrameworkCore;

namespace EaterClone.Services;

public class DishService(AppDbContext dbContext, DishRepository dishRepository, ProductRepository productRepository)
{
    public async Task<DishDto> Create(CreateDishDto createDishDto)
    {
        var products = await productRepository.FindAllByIds(createDishDto.ProductsId);
        var dish = new DishEntity
        {
            Name = createDishDto.Name,
            Weight = createDishDto.Weight,
            Products = products,
            PictureUrl = createDishDto.PictureUrl,
            UserId = createDishDto.UserId
        };

        await dishRepository.Create(dish);

        return new DishDto
        {
            Id = dish.Id,
            Name = dish.Name,
            Weight = dish.Weight,
            ProductsId = dish.Products.Select(x => x.Id).ToList(),
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
                ProductsId = x.Products.Select(p => p.Id).ToList(),
                PictureUrl = x.PictureUrl,
                UserId = x.UserId
            }).ToList();
    }

    public async Task<DishDto> FindById(Guid id)
    {
        var dish = await dbContext.DishEntities.FirstAsync(x => x.Id == id);
        return new DishDto
        {
            Id = dish.Id,
            Name = dish.Name,
            Weight = dish.Weight,
            ProductsId = dish.Products.Select(x => x.Id).ToList(),
            PictureUrl = dish.PictureUrl,
            UserId = dish.UserId
        };
    }
}