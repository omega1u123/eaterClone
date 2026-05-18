using EaterClone.Domain.Entities;
using EaterClone.Domain.Repository;
using EaterClone.Models;

namespace EaterClone.Services;

public class MealService(MealRepository mealRepository, DishRepository dishRepository)
{
    public async Task<MealDto> CreateMeal(CreateMealDto createMealDto)
    {
        var dishes = await dishRepository.FindAllByIds(createMealDto.DishIds);
        
        var meal = new MealEntity
        {
            Name = createMealDto.Name,
            RationId = createMealDto.RationId,
            Dishes = dishes
        };
        
        await mealRepository.Create(meal);

        return new MealDto
        {
            Id = meal.Id,
            Name = meal.Name,
            RationId = meal.RationId,
            DishIds = dishes.Select(x => x.Id).ToList()
        };
    }

    public async Task<List<MealEntity>> CreateDefaultMeals(Guid rationId)
    {
        var meals = new List<MealEntity>
        {
            new MealEntity
            {
                Name = "Завтрак",
                RationId = rationId,
                Dishes = []
            },
            new MealEntity
            {
                Name = "Обед",
                RationId = rationId,
                Dishes = []
            },
            new MealEntity
            {
                Name = "Ужин",
                RationId = rationId,
                Dishes = []
            }
        };
        
        await mealRepository.CreateMany(meals);

        return meals;
        
    }

    public async Task<MealDto> FindById(Guid mealId)
    {
        var meal = await mealRepository.FindById(mealId);
        return new MealDto
        {
            Id = meal!.Id,
            Name = meal.Name,
            RationId = meal.RationId,
            DishIds = meal.Dishes.Select(y => y.Id).ToList()
        };
    }

    public async Task<MealDto> AddMealToDish(UpdateMealDto updateMealDto)
    {
        var meal = await mealRepository.FindById(updateMealDto.MealId);
        var dish = await dishRepository.FindById(updateMealDto.DishId);
        meal!.Dishes.Add(dish!);
        await mealRepository.Update(meal);

        return new MealDto
        {
            Id = meal.Id,
            Name = meal.Name,
            RationId = meal.RationId,
            DishIds = meal.Dishes.Select(y => y.Id).ToList()
        };
    }

    public async Task<MealDto> RemoveDishFromMeal(UpdateMealDto updateMealDto)
    {
        var meal = await mealRepository.FindById(updateMealDto.MealId);
        var dish = await dishRepository.FindById(updateMealDto.DishId);
        meal!.Dishes.Remove(dish!);
        await mealRepository.Update(meal);

        return new MealDto
        {
            Id = meal.Id,
            Name = meal.Name,
            RationId = meal.RationId,
            DishIds = meal.Dishes.Select(y => y.Id).ToList()
        };
    }
}