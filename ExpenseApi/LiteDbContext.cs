﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.Extensions.Options;

namespace ExpenseApi
{
    public class LiteDbContext : ILiteDbContext
    {
        
        public LiteDbContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                var db = new LiteDatabase(configs.Value.DatabasePath);
                Context = db;
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        public LiteDatabase Context { get; }
    }
}
