using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trade.Data.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetAll();
        Task<T> Get(int id);
        
        Task<T> Insert(T data);
        Task<IEnumerable<T>> InsertMany(IEnumerable<T> data);
        
        Task Update(T data);
        Task UpdateMany(IEnumerable<T> data);
        
        Task Delete(int id);
        Task DeleteMany(IEnumerable<int> ids);
    }
}