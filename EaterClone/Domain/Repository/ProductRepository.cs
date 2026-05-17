using EaterClone.Domain.Entities;

namespace EaterClone.Domain.Repository;

public class ProductRepository(AppDbContext appDbContext) : BaseRepository<ProductEntity>(appDbContext)
{
    
}