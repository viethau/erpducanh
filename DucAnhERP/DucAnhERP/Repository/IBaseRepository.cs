using System.Collections.Generic;
using System.Threading.Tasks;

namespace DucAnhERP.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById(string id);
        Task<List<T>> GetAll();
        Task Update(T entity);
        Task UpdateMulti(T[] entities);
        Task DeleteById(string id);
        Task<bool> CheckExclusive(string[] ids, DateTime baseTime);
        Task Insert(T entity);
    }
}