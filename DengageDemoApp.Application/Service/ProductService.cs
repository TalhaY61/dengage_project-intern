using DengageDemoApp.Application.Mapper;
using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                var getAllProducts = _dbContext.Product.ToList();

                return getAllProducts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error by getting Product: {ex.Message}");
                throw;
            }
        }

        public ProductModel GetProductByID(int id)
        {
            var getProduct = _dbContext.Product.Find(id);

            return ProductsMapper.MapFromDomain(getProduct);
        }

        public Product AddProduct(Product product)
        {
            try
            {
                //check if the Product you want to add exist.
                
                /*var existingProduct = _dbContext.Product.Find(product.ID);
                if (existingProduct != null)
                {
                    throw new ArgumentException("Product with the same ID already exists!");
                } */

                //If not create here a new Product
                _dbContext.Product.Add(product);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
                throw;

            }
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            //check if the Product exist you want to update.
            var existingProduct = _dbContext.Product.Find(product.ID);
            if (existingProduct != null)
            {
                _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                _dbContext.SaveChanges();
            }

            return existingProduct;
        }

        public Product DeleteProductByID(int id)
        {
            //check if the Product exist you want to delete by ID.
            var deletedProduct = _dbContext.Product.Find(id);
            if (deletedProduct != null)
            {
                _dbContext.Product.Remove(deletedProduct);
                _dbContext.SaveChanges();
            }

            return deletedProduct;
        }

    }
}
