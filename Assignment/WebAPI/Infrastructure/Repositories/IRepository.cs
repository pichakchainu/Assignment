using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Repositories
{
   public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        bool Add(T item);
        bool Update(T item);
        bool Delete(int id);

    }
}
