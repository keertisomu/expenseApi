using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseApi
{
    public static class DbServiceExtensions
    {
        public static void RegisterRepositoryInstances(this IServiceCollection services, string databasePath)
        {
            IDbConfig dbConfig = new LiteDbConfig()
            {
                DatabasePath = databasePath
            };
         
            services.AddSingleton<IDbConfig>(dbConfig);
            services.AddSingleton<IRepository<Expense>, ExpenseRepository>();
            
        }
    }
}
