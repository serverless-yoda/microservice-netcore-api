using CodeCheater.Application.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeCheater.Domain.Models.Categories;

namespace CodeCheater.Category.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Models.Categories.Category>>> GetAllCategories()
        {
           var categories =  await this.service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        public async Task<ActionResult<Domain.Models.Categories.Category>> GetById(int id)
        {
            var category = await this.service.GetAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Domain.Models.Categories.Category>> Post(Domain.Models.Categories.Category newCategory)
        {
            await this.service.InsertAsync(newCategory);
            return Ok(newCategory);
        }

        [HttpPut]
        public async Task<ActionResult<Domain.Models.Categories.Category>> Put(Domain.Models.Categories.Category newCategory)
        {
            await this.service.UpdateAsync(newCategory);
            return Ok(newCategory);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var category = await this.service.GetAsync(id);
            bool result = false;
            if(category != null)
            {
               result =  await this.service.DeleteAsync(id);
            }

            return Ok(result);
        }

    }
}
