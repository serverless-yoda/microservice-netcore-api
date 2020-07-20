using CodeCheater.Domain.Models.Baskets;
using CodeCheater.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CodeCheater.Application.Service
{
    public class BasketService : IBasketService
    {
        private readonly IRedisUnitOfWork uow;

        public BasketService(IRedisUnitOfWork uow)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<bool> DeleteAsync(string userName)
        {
            return await this.uow.BasketRepository.Delete(userName);
        }

        public async Task<BasketCart> GetAsync(string userName)
        {
            return await this.uow.BasketRepository.Get(userName);
        }

        public async Task<BasketCart> UpdateAsync(string userName, BasketCart entryObject)
        {
            return await this.uow.BasketRepository.Update(userName, entryObject);
        }
    }
}
