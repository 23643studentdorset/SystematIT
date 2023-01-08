using System.Linq.Expressions;

namespace Infrastucture.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> FindByCondition(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> FindListByCondition(Expression<Func<T, bool>> predicate);
        
        //Task<IEnumerable<T>> FindListByTwoConditions(Expression<Func<T, bool>> predicate1, Expression<Func<T, bool>> predicate2);

        Task Insert(T entity);
        
        Task Update(T entity);

        Task Delete(T entity);
    }
}
