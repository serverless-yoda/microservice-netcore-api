using System.Threading.Tasks;

namespace CodeCheater.Domain.Repositories
{
    public interface IRedisUnitOfWork
    {
        IBasketRepository BasketRepository { get; }
    }
}
