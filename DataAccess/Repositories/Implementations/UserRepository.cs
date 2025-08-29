using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Domain.Models.Entities;

namespace DataAccess.Repositories.Implementations
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(DBContext dBContext) : base(dBContext)
        { }

        public Users GetUserByEmail(string email)
        {
            return _entity.Where(x => x.Email == email).FirstOrDefault();
        }
    }

}
