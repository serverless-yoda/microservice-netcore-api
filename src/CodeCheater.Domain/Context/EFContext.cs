using CodeCheater.Domain.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace CodeCheater.Domain.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
