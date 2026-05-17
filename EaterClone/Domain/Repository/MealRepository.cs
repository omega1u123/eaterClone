using EaterClone.Domain.Entities;

namespace EaterClone.Domain.Repository;

public class MealRepository(AppDbContext dbContext) : BaseRepository<MealEntity>(dbContext)
{
    
}