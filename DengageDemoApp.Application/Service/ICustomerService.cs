using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Service
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        CustomerModel GetCustomerByID(int id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer DeleteCustomerByID(int id);
    }
}
