using CodeCheater.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeCheater.Application.Service
{
    public interface ICategoryService
    {
        Task<bool> DeleteAsync(int id);
        Task<Category> GetAsync(int id);
        Task<Category> UpdateAsync(Category entryObject);
        Task<Category> InsertAsync(Category entryObject);
    }
}
