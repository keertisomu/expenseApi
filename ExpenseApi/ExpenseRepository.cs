using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Microsoft.Extensions.Options;

namespace ExpenseApi
{
    public class ExpenseRepository : IRepository<Expense>
    {
        private LiteDatabase _databaseContext { get; }

        public ExpenseRepository(IDbConfig config)
        {
            try
            {
                var db = new LiteDatabase(config.DatabasePath);
                _databaseContext = db;
            }
            catch (Exception ex)
            {
                throw new Exception("an error occured while creating database context", ex);
            }
        }
        public IEnumerable<Expense> FindAll()
        {
            return _databaseContext.GetCollection<Expense>("expense")
                .FindAll();
        }

        public Expense FindOne(string id)
        {
            return _databaseContext.GetCollection<Expense>("expense")
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public string Insert(Expense expense)
        {
            return _databaseContext.GetCollection<Expense>("expense")
                .Insert(expense);
        }

        public bool Update(Expense expense)
        {
            return _databaseContext.GetCollection<Expense>("expense")
                .Update(expense);
        }

        public bool Delete(string id)
        {
            return _databaseContext.GetCollection<Expense>("expense")
                .Delete(id);
        }
    }
}
