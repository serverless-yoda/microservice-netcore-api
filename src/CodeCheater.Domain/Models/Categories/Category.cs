using CodeCheater.Domain.Repositories;

namespace CodeCheater.Domain.Models.Categories
{
    public class Category : Entity
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
