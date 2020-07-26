namespace CodeCheater.Domain.Repositories
{
    public interface IEntityBase<Tid>
    {
        Tid Id { get; }
    }
}
