using CodeCheater.Domain.Models.Baskets;
using System.Threading.Tasks;

namespace CodeCheater.Domain.Repositories
{
    public interface IBaseRedisRepository<T>: IBaseRedis<T> where T: class
    {
        Task<T> Get(string userName);
        Task<bool> Delete(string userName);
        Task<T> Update(string userName, T entryObject);

    }
}
