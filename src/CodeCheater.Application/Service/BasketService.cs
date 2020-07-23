using CodeCheater.Domain.Models.Baskets;
using CodeCheater.Domain.Repositories;
using CodeCheater.Infrastructure.ValidationException;
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
            if (string.IsNullOrEmpty(userName)) throw new ApplicationValidationException("UserName is empty in DeleteAsync");
            return await this.uow.BasketRepository.Delete(userName);
        }

        public async Task<BasketCart> GetAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new ApplicationValidationException("UserName is empty in GetAsync");
            return await this.uow.BasketRepository.Get(userName);
        }

        public async Task<BasketCart> UpdateAsync(string userName, BasketCart entryObject)
        {
            if (string.IsNullOrEmpty(userName)) throw new ApplicationValidationException("UserName is empty in UpdateAsync");
            return await this.uow.BasketRepository.Update(userName, entryObject);
        }
    }
}
