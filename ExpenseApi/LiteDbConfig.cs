using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApi
{
    public class LiteDbConfig : IDbConfig
    {
        public string DatabasePath { get; set; }
    }

    public interface IDbConfig
    {
        string DatabasePath { get; set; }
    }
}
