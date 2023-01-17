using Infrastucture.DataAccess.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastucture.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindListByCondition(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        /*
        public async Task<IEnumerable<T>> FindListByTwoConditions(Expression<Func<T, bool>> predicate1, Expression<Func<T, bool>> predicate2)
        {
            var combinedPredicate = PredicateBuilder.And(predicate1, predicate2);
            return await _context.Set<T>().Where(combinedPredicate).ToListAsync();
        }
        */
        public virtual async Task Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
