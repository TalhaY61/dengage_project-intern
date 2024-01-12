using DengageDemoApp.Contract.Model;
using DengageDemoApp.Contract.Response;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Service
{
    public interface ICategoryService
    {
        //IEnumerable<CategoryModel> GetAllCategory();
        IEnumerable<CategoryResponse> GetAllCategory();

        //CategoryModel GetCategoryByID(int id);
        CategoryResponse GetCategoryByID(int id);

        Category AddCategory(Category category);
        Category UpdateCategory(Category category);
        Category DeleteCategoryByID(int id);
    }
}
