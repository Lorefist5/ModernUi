using System.Linq.Expressions;

namespace ModernUi.Data.Repositories.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter);
        Task Add(T entity);
        Task Delete(T entity);

        Task<IEnumerable<T>> GetFiltered(Expression<Func<T, bool>> filter);
    }
}