namespace CodeCheater.Domain.Repositories
{
    public interface IEFcoreUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
    }
}
