using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class TicketRepository : Repository<Tickets> , ITicketRepository
    {
        public TicketRepository(DBContext context) : base(context) { }

        public async Task<Dictionary<string, int>> GetTicketCountByStatus()
        {
            return await _entity.GroupBy(t=>t.Status.ToString()).
                Select(g=> new {Status = g.Key, Count = g.Count()}).
                ToDictionaryAsync(item=>item.Status, item=>item.Count);
        }

        public async Task<IEnumerable<Tickets>> GetTicketsByUserId(Guid userId) => await
            _entity.Where(x=>x.CreatedByUserId == userId).ToListAsync();

    }
}
