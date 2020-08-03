using CodeCheater.Domain.Context;
using System;

namespace CodeCheater.Domain.Repositories
{
    public class EFCoreUnitOfWork : IEFcoreUnitOfWork
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly EFContext context;

        public EFCoreUnitOfWork(ICategoryRepository categoryRepository, EFContext context)
        {
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ICategoryRepository CategoryRepository => categoryRepository;
    }
}
