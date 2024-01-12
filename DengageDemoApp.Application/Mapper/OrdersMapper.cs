using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Mapper
{
    public static class OrdersMapper
    {
        public static OrdersModel MapFromDomain(Orders orders)
        {
            return new OrdersModel
            {
                ID = orders.ID,
                status = orders.status,
                customer_ID = orders.customer_ID,
                product_ID = orders.product_ID,
                createdBy = orders.createdBy,
                createdAt = orders.createdAt,
                updatedBy = orders.updatedBy,
                updatedAt = orders.updatedAt,
            };
        }
    }
}
