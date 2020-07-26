using StackExchange.Redis;

namespace CodeCheater.Domain.Repositories
{
    public interface IBaseRedis<T> where T: class
    {
        IDatabase Db { get; }
    }
}
