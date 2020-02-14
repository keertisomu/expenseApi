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

        public LiteDbExpenseService(LiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Context;
        }

        public Expense FindOne(int id)
        {
            return _liteDb.GetCollection<Expense>("Expense")
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public bool Insert(Expense expense)
        {
            return _liteDb.GetCollection<Expense>("Api")
                .Insert(expense);
        }

        public bool Update(Expense expense)
        {
            return _liteDb.GetCollection<Expense>("Api")
                .Update(expense);
        }

        //public int Delete(string id)
        //{
        //    return _liteDb.GetCollection<Expense>("Api")
        //        .Delete(x => x.Id == id);
        //}
    }
}
