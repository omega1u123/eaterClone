using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EaterClone.Domain.Repository;

public class ProductRepository(AppDbContext appDbContext) : BaseRepository<ProductEntity>(appDbContext)
{
}