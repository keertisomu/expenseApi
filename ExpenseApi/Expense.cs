using System;

namespace ExpenseApi
{
    public class Expense
    {
        public DateTime Created { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Value { get; set; }

        public string Currency { get; set; }
    }  
}
