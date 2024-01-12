using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Service
{
    public interface IOrdersService
    {
        IEnumerable<Orders> GetAllOrders();
        OrdersModel GetOrdersByID(int id);
        Orders AddOrders(Orders orders);
        Orders UpdateOrders(Orders orders);
        Orders DeleteOrdersByID(int id);
    }
}
