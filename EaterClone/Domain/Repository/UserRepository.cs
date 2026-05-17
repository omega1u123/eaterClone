using EaterClone.Domain.Entities;

namespace EaterClone.Domain.Repository;

public class UserRepository(AppDbContext appDbContext) : BaseRepository<UserEntity>(appDbContext)
{
    
}