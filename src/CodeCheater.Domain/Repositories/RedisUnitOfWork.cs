﻿using StackExchange.Redis;
using System;

namespace CodeCheater.Domain.Repositories
{
    public class RedisUnitOfWork : IRedisUnitOfWork
    {
        private readonly ConnectionMultiplexer cm;
        private readonly IBasketRepository _basketRepository;

        public RedisUnitOfWork(ConnectionMultiplexer cm, IBasketRepository basketRepository)
        {
            this.cm = cm ?? throw new ArgumentNullException(nameof(cm));
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }
        public IBasketRepository BasketRepository => _basketRepository;
    }
}
