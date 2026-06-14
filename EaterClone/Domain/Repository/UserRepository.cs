using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EaterClone.Domain.Repository;

public class UserRepository(AppDbContext appDbContext) : BaseRepository<UserEntity>(appDbContext)
{
   public async Task<UserEntity?> FindByNameAndPassword(string username, string password)
   {
      return await appDbContext.UserEntities.Where(x => x.Name == username && x.Password == password).FirstOrDefaultAsync();
   }
}