using CodeCheater.Domain.Repositories;

namespace CodeCheater.Domain.Models.Categories
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
