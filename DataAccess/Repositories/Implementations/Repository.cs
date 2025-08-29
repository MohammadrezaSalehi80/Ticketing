using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        protected readonly DBContext _context;
        protected readonly DbSet<Entity> _entity;
        public Repository(DBContext dBContext)
        {
            _context = dBContext;
            _entity = dBContext.Set<Entity>();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync() => await _entity.ToListAsync();

        public async Task<Entity> GetAsync(Guid id) => await _entity.FindAsync(id);

        public async Task AddAsync(Entity entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);

            if (entity != null)
            {
                _entity.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }


        public async Task UpdateAsync(Entity entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
