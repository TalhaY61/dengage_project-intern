using DengageDemoApp.Application.Service;
using DengageDemoApp.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DengageDemoApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public IActionResult GetAllOrderss()
        {
            var getAllOrders = _ordersService.GetAllOrders();
            return Ok(getAllOrders);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrdersByID([FromRoute]int id)
        {
            var getOrders = _ordersService.GetOrdersByID(id);

            return Ok(getOrders);
        }

        [HttpPost]
        public IActionResult AddOrders(Orders orders)
        {
            var newOrders = _ordersService.AddOrders(orders);

            return CreatedAtAction(nameof(GetOrdersByID), new { id = newOrders.ID }, newOrders);

        }

        //try to return previous and new updated Data of the Orders
        [HttpPut]
        public IActionResult UpdateOrders(Orders orders)
        {
            var updatedOrders = _ordersService.UpdateOrders(orders);

            return Ok(updatedOrders);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrdersByID(int id)
        {
            var deletedOrders = _ordersService.DeleteOrdersByID(id);

            return Ok(deletedOrders);
        }
    }
}
