using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EaterClone.Domain.Repository;

public abstract class BaseRepository<T>(AppDbContext dbContext)
    where T : BaseEntity
{
    protected readonly AppDbContext DbContext = dbContext; 


    public async Task Create(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task<List<T>> CreateMany(List<T> entities)
    {
        await DbContext.Set<T>().AddRangeAsync();
        await DbContext.SaveChangesAsync();
        return entities;
    }
    
    public async Task<T?> FindById(Guid id)
    {
        var entity = await DbContext.Set<T>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        return entity;
    }

    public async Task<List<T>> FindAllByIds(List<Guid> ids)
    {
        var entities = await DbContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
        return entities;
    }

    public async Task DeleteById(Guid id)
    {
        await DbContext.Set<T>().Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<T> Update(T entity)
    {
        DbContext.Update(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    } 
    
    public async Task<bool>  Exists(Guid id)
    {
        return await DbContext.Set<T>().Where(x => x.Id == id).AnyAsync();
    }
}