using EaterClone.Domain.Entities;
using EaterClone.Domain.Repository;
using EaterClone.Models;

namespace EaterClone.Services;

public class RationService(RationRepository rationRepository, MealService mealService)
{
    public async Task<RationDto> Create(DateOnly date)
    {
        var ration = new RationEntity
        {
            Date = DateOnly.FromDateTime(DateTime.UtcNow),
            UserId = Guid.NewGuid(), //TODO add normal userid
            Meals = []
        };
        await rationRepository.Create(ration);
        var meals = await mealService.CreateDefaultMeals(ration.Id);
        ration.Meals.AddRange(meals.Select(x => x.Id).ToList());

        await rationRepository.Update(ration);

        return new RationDto
        {
            Id = ration.Id,
            Date = ration.Date,
            MealIds = ration.Meals
        };
    }

    public async Task<RationDto> FindByDate(DateOnly date)
    {
        var ration = await rationRepository.FindByDate(date);
        return new RationDto
        {
            Id =  ration!.Id,
            Date = ration.Date,
            MealIds = ration.Meals
        };
    }
    
    
}