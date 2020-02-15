using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseApi
{
    public static class LiteDbServiceExtenstion
    {
        public static void AddLiteDb(this IServiceCollection services, string databasePath)
        {
            services.AddSingleton<ILiteDbContext, LiteDbContext>();
            services.AddSingleton<LiteDbExpenseService, LiteDbExpenseService>();
            services.Configure<LiteDbConfig>(options => options.DatabasePath = databasePath);
        }
    }
}
