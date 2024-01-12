using DengageDemoApp.Application.Mapper;
using DengageDemoApp.Contract.Model;
using DengageDemoApp.Contract.Response;
using DengageDemoApp.Domain;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DengageDemoApp.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;

        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*
        public IEnumerable<CategoryModel> GetAllCategory()
        {
            try
            {
                var getAllCategory = _dbContext.Category.ToList();

                return CategoryMapper.MapListFromDomain(getAllCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error by getting Category: {ex.Message}");
                throw;
            }
        } 

        public CategoryModel GetCategoryByID(int id)
        {
            var getCategory = _dbContext.Category.Find(id);

            return CategoryMapper.MapFromDomain(getCategory);
        } */
        public IEnumerable<CategoryResponse> GetAllCategory()
        {
            try
            {
                var getAllCategory = _dbContext.Category.ToList();
                return getAllCategory.Select(category => new CategoryResponse
                {
                    ID = category.ID,
                    name = category.name
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error by getting Category: {ex.Message}");
                throw;
            }
        }

        public CategoryResponse GetCategoryByID(int id)
        {
            var getCategory = _dbContext.Category.Find(id);
            if (getCategory == null)
            {
                return null; // Category not found
            }

            return new CategoryResponse
            {
                ID = getCategory.ID,
                name = getCategory.name
            };
        }

        //Would be try-catch better than an if-statement?
        public Category AddCategory(Category category)
        {
            try
            {
                /*
                //check if the Category you want to add exist.
                var existingCategory = _dbContext.Category.Find(category.ID);

                 * if (existingCategory != null)
                {
                    throw new ArgumentException("Category with the same ID already exists!");
                } */

                //If not create here a new Category
                _dbContext.Category.Add(category);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
                throw;

            }
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            //check if the Category exist you want to update.
            var existingCategory = _dbContext.Category.Find(category.ID);
            if (existingCategory != null)
            {
                _dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                _dbContext.SaveChanges();
            }

            return existingCategory;
        }

        public Category DeleteCategoryByID(int id)
        {
            //check if the Category exist you want to delete by ID.
            var deletedCategory = _dbContext.Category.Find(id);
            if (deletedCategory != null)
            {
                _dbContext.Category.Remove(deletedCategory);
                _dbContext.SaveChanges();
            }

            return deletedCategory;
        }
    }
}
