using EaterClone.Domain.Entities;
using EaterClone.Domain.Repository;
using EaterClone.Models;

namespace EaterClone.Services;

public class MealService(MealRepository mealRepository)
{
    public async Task<MealDto> CreateMeal(CreateMealDto createMealDto)
    {
        var meal = new MealEntity
        {
            Name = createMealDto.Name,
            RationId = createMealDto.RationId,
            DishIds = createMealDto.DishIds
        };
        
        await mealRepository.Create(meal);

        return new MealDto
        {
            Id = meal.Id,
            Name = meal.Name,
            RationId = meal.RationId,
            DishIds = meal.DishIds
        };
    }

    public async Task<List<MealDto>> CreateDefaultMeals(Guid rationId)
    {
        var meals = new List<MealEntity>
        {
            new MealEntity
            {
                Name = "Завтрак",
                RationId = rationId,
                DishIds = []
            },
            new MealEntity
            {
                Name = "Обед",
                RationId = rationId,
                DishIds = []
            },
            new MealEntity
            {
                Name = "Ужин",
                RationId = rationId,
                DishIds = []
            }
        };
        
        await mealRepository.CreateMany(meals);

        return meals.Select(x =>
            new MealDto
            {
                Id = x.Id,
                Name = x.Name,
                RationId = x.RationId,
                DishIds = x.DishIds
            }
        ).ToList();
        
    }

    public async Task<MealDto> FindById(Guid mealId)
    {
        var meal = await mealRepository.FindById(mealId);
        return new MealDto
        {
            Id = meal!.Id,
            Name = meal.Name,
            RationId = meal.RationId,
            DishIds = meal.DishIds
        };
    }

    public async Task<MealDto> AddMealToDish(UpdateMealDto updateMealDto)
    {
        var meal = await mealRepository.FindById(updateMealDto.MealId);
        meal!.DishIds.Add(updateMealDto.DishId);
        await mealRepository.Update(meal);

        return new MealDto
        {
            Id = meal.Id,
            Name = meal.Name,
            RationId = meal.RationId,
            DishIds = meal.DishIds
        };
    }

    public async Task<MealDto> RemoveDishFromMeal(UpdateMealDto updateMealDto)
    {
        var meal = await mealRepository.FindById(updateMealDto.MealId);
        meal!.DishIds.Remove(updateMealDto.DishId);
        await mealRepository.Update(meal);

        return new MealDto
        {
            Id = meal.Id,
            Name = meal.Name,
            RationId = meal.RationId,
            DishIds = meal.DishIds
        };
    }
}