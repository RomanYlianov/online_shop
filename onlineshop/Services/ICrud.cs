using System.Collections.Generic;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface ICrud <T, TID> 
    {
        Task<List<T>> GetAll();

        Task<T> GetById(TID id);

        Task<T> Add(T item);

        Task<T> Update(T item);

        Task Delete(TID id);

    }
}
