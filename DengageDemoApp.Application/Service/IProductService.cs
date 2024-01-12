using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        ProductModel GetProductByID(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProductByID(int id);
    }
}
