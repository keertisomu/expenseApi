using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApi
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        T FindOne(int id);
        int Insert(T expense);
        bool Update(T expense);
        bool Delete(int id);
    }
}
