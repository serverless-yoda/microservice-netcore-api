using CodeCheater.Domain.Models.Baskets;
using System.Threading.Tasks;

namespace CodeCheater.Application.Service
{
    public interface IBasketService
    {
        Task<bool> DeleteAsync(string userName);
        Task<BasketCart> GetAsync(string userName);
        Task<BasketCart> UpdateAsync(string userName, BasketCart entryObject);

    }
}
