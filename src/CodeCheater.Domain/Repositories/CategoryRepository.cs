using CodeCheater.Domain.Context;
using CodeCheater.Domain.Models.Categories;

namespace CodeCheater.Domain.Repositories
{
    public class CategoryRepository : BaseEFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EFContext db) : base(db)
        {
        }
    }
}
