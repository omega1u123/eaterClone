using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EaterClone.Domain.Repository;

public class RationRepository(AppDbContext appDbContext) : BaseRepository<RationEntity>(appDbContext)
{
    public async Task<RationEntity?> FindByDate(DateOnly date)
    {
        return await DbContext.RationEntities.Where(x => x.Date == date).FirstOrDefaultAsync();
    }
}