using DengageDemoApp.Application.Service;
using DengageDemoApp.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DengageDemoApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var getAllCustomers = _customerService.GetAllCustomers();
            return Ok(getAllCustomers);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCustomerByID([FromRoute]int id)
        {
            var getCustomer = _customerService.GetCustomerByID(id);

            return Ok(getCustomer);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var newCustomer = _customerService.AddCustomer(customer);

            return CreatedAtAction(nameof(GetCustomerByID), new { id = newCustomer.ID }, newCustomer);

        }

        //try to return previous and new updated Data of the Customer
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer) 
        {
            var updatedCustomer = _customerService.UpdateCustomer(customer);

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerByID(int id)
        {
            var deletedCustomer = _customerService.DeleteCustomerByID(id);

            return Ok(deletedCustomer);
        }
    }
}
