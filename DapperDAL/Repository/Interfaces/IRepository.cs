using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL.Repository.Interfaces
{
    public interface IRepository<T, U>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(U Id);
        Task<int> DeleteItemAsync(U Id);
        Task<int> DeleteItemsAsync(List<U> Ids);
        Task<U> AddAsync(T Model);

    }
}
