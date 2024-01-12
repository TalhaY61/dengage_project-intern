using DengageDemoApp.Application.Mapper;
using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DengageDemoApp.Application.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _dbContext;

        public OrdersService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            try
            {
                var getAllOrders = _dbContext.Orders.ToList();

                return getAllOrders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error by getting Orders: {ex.Message}");
                throw;
            }
        }

        public OrdersModel GetOrdersByID(int id)
        {
            var getOrder = _dbContext.Orders.Find(id);

            return OrdersMapper.MapFromDomain(getOrder);
        }

        public Orders AddOrders(Orders orders)
        {
            try
            {
                //If not create here a new Order
                _dbContext.Orders.Add(orders);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
                throw;
            }

            return orders;
        }

        public Orders UpdateOrders(Orders orders)
        {
            //check if the Order exist you want to update.
            var existingOrders = _dbContext.Orders.Find(orders.ID);
            if (existingOrders != null)
            {
                _dbContext.Entry(existingOrders).CurrentValues.SetValues(orders);
                _dbContext.SaveChanges();
            }

            return existingOrders;
        }

        public Orders DeleteOrdersByID(int id)
        {
            //check if the Orders exist you want to delete by ID.
            var deletedOrders = _dbContext.Orders.Find(id);
            if (deletedOrders != null)
            {
                _dbContext.Orders.Remove(deletedOrders);
                _dbContext.SaveChanges();
            }

            return deletedOrders;
        }
    }
}
