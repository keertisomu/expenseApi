using LiteDB;

namespace ExpenseApi
{
    public interface ILiteDbContext
    {
        LiteDatabase Context { get; }
    }
}