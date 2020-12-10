using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApi
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        T FindOne(string id);
        string Insert(T expense);
        bool Update(T expense);
        bool Delete(string id);
    }
}
