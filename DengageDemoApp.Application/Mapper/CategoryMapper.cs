using DengageDemoApp.Contract.Model;
using DengageDemoApp.Contract.Response;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryModel MapFromDomain(Category category)
        {
            return new CategoryModel
            {
                ID = category.ID,
                name = category.name,
                createdBy = category.createdBy,
                createdAt = category.createdAt,
                updatedBy = category.updatedBy,
                updatedAt = DateTime.Now,
                //can we use Datetime.Now?
                //createdAt o objenin ne zaman create oldugu vakit olsun
                // ama updatedAt her zaman güncellensin, ondan dolayi DataTime.Now dedim.
            };
        }
        
        public static IEnumerable<CategoryModel> MapListFromDomain(List<Category> getAllCategory)
        {
            return getAllCategory.Select(MapFromDomain).ToList();

        } 
    }
}
