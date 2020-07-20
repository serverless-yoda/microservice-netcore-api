using CodeCheater.Domain.Models.Baskets;
using StackExchange.Redis;

namespace CodeCheater.Domain.Repositories
{
    public class BasketRepository : 
        BaseRedisRepository<BasketCart>,
        IBasketRepository
    {
        public BasketRepository(ConnectionMultiplexer connectionMultiplexer) 
            : base(connectionMultiplexer){ }
    }
}
