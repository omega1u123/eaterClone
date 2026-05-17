using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EaterClone.Domain.Repository;

public class DishRepository(AppDbContext dbContext) : BaseRepository<DishEntity>(dbContext)
{
    public async Task<List<DishEntity>> FindAllByUserId(Guid userId)
    {
        var dish = await DbContext.DishEntities.Where(x => x.UserId == userId).ToListAsync();
        return dish;
    }
}