using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Mapper
{
    public static class ProductsMapper
    {
        public static ProductModel MapFromDomain(Product product)
        {
            return new ProductModel
            {
                ID = product.ID,
                name = product.name,
                price = product.price,
                category_ID = product.category_ID,
                createdBy = product.createdBy,
                createdAt = product.createdAt,
                updatedBy = product.updatedBy,
                updatedAt = product.updatedAt,
            };
        }
    }
}
