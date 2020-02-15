using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace ExpenseApi
{
    public class LiteDbExpenseService
    {
        private LiteDatabase _liteDb;

        public LiteDbExpenseService(ILiteDbContext dBcontext)
        {
            _liteDb = dBcontext.Context;
        }

        public IEnumerable<Expense> FindAll()
        {
            return _liteDb.GetCollection<Expense>("Api")
                .FindAll();
        }

        public Expense FindOne(int id)
        {
            return _liteDb.GetCollection<Expense>("Api")
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(Expense expense)
        {
            return _liteDb.GetCollection<Expense>("Api")
                .Insert(expense);
        }

        //public bool Update(Expense expense)
        //{
        //    return _liteDb.GetCollection<Expense>("Api")
        //        .Update(expense);
        //}

        //public int Delete(string id)
        //{
        //    return _liteDb.GetCollection<Expense>("Api")
        //        .Delete(x => x.Id == id);
        //}
    }

    public interface ILiteDbExpenseService
    {

    }
}
