using DengageDemoApp.Application.Service;
using DengageDemoApp.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DengageDemoApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategorys()
        {
            var getAllCategory = _categoryService.GetAllCategory();
            return Ok(getAllCategory);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategoryByID([FromRoute] int id)
        {
            var getCategory = _categoryService.GetCategoryByID(id);
            return Ok(getCategory);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody]Category category)
        {
            var newCategory = _categoryService.AddCategory(category);

            return CreatedAtAction(nameof(GetCategoryByID), new { id = newCategory.ID }, newCategory);

        }

        //try to return previous and new updated Data of the Category
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var updatedCategory = _categoryService.UpdateCategory(category);

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryByID(int id)
        {
            var deletedCategory = _categoryService.DeleteCategoryByID(id);

            return Ok(deletedCategory);
        }
    }
}
