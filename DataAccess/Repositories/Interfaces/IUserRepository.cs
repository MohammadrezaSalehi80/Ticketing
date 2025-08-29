using Domain.Models.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<Users>
    {
        Users GetUserByEmail(string email);
    }

}
