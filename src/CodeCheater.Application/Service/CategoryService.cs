using CodeCheater.Domain.Models.Categories;
using CodeCheater.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeCheater.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IEFcoreUnitOfWork uow;

        public CategoryService(IEFcoreUnitOfWork uow)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var toDelete = await GetAsync(id);
            if (toDelete != null)
            {
                await this.uow.CategoryRepository.DeleteAsync(toDelete);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await this.uow.CategoryRepository.GetAllAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await this.uow.CategoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> InsertAsync(Category entryObject)
        {
            await this.uow.CategoryRepository.AddAsync(entryObject);
            return entryObject;
        }

        public async Task<bool> IsCategoryNameExist(string name)
        {
            var result =  await this.uow.CategoryRepository.GetAsync(c => c.Name == name);
            if (result != null) return false;
            return true;
        }

        public async Task<Category> UpdateAsync(Category entryObject)
        {
            await this.uow.CategoryRepository.UpdateAsync(entryObject);
            return entryObject;
        }
    }
}
