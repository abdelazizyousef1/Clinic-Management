using clinic.Repository.IRepository;
using clinic.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
namespace clinic.Repository
{
    /*public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        public BaseRepository(AppDbContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbset = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
         return await _dbset.FindAsync(Id);
            
           
        }
        public async Task AddAsync(T Entity)
        {
           await _dbset.AddAsync(Entity);   
            await _context.SaveChangesAsync();
        }
       public async Task UpdateAsync(T Entity)
        {
            _dbset.Update(Entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int Id)
        {
            var entity = await _dbset.FindAsync(Id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                await _context.SaveChangesAsync();
            }
           
        }
    }*/
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;

        public BaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbset = context.Set<T>();
        }

        
        public async Task<List<T>> GetAllAsync()
        {
            if (_dbset == null) throw new InvalidOperationException("Database set is not initialized.");
            return await _dbset.ToListAsync();
        }

        
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        
        public async Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbset.AddAsync(entity); 
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity == null) return false;

            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
