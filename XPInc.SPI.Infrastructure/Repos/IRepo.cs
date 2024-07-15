using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Infrastructure.Repos
{
    public interface IRepo<T>
    {
        Task<IEnumerable<T>> GetAll(int pageIndex = 1, int pageSize = 10);
        Task<T> Get(int id);
        Task Add(T item);
        Task Edit(int id, T item);
        Task Delete(int id);
    }
}
