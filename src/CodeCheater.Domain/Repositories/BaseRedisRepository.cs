using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace CodeCheater.Domain.Repositories
{
    public class BaseRedisRepository<T> : IBaseRedisRepository<T> where T : class
    {
        private readonly ConnectionMultiplexer connectionMultiplexer;
        public BaseRedisRepository(ConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer 
                ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            Db = this.connectionMultiplexer.GetDatabase();
        }
        public IDatabase Db { get; }
        public async Task<bool> Delete(string userName)
        {
            return await Db.KeyDeleteAsync(userName);
        }
        public async Task<T> Get(string userName)
        {
            var result = await Db.StringGetAsync(userName);
            if (result.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(result);
        }
        public async Task<T> Update(string userName, T entryObject)
        {
            var result = await Db.StringSetAsync(userName, JsonConvert.SerializeObject(entryObject));
            if (!result)
            {
                return null;
            }
            return await Get(userName);
        }
    }
}
