using Domain.Models.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITicketRepository : IRepository<Tickets>
    {
        Task<IEnumerable<Tickets>> GetTicketsByUserId(Guid userId);
        Task<Dictionary<string, int>> GetTicketCountByStatus();
    }

}
