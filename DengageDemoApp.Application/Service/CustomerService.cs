using DengageDemoApp.Application.Mapper;
using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain;
using DengageDemoApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _dbContext;

        public CustomerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                var getAllCustomer = _dbContext.Customer.ToList();

                return getAllCustomer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error by getting Customer: {ex.Message}");
                throw;
            }
        }

        public CustomerModel GetCustomerByID(int id)
        {
            var getCustomer = _dbContext.Customer.Find(id);

            return CustomerMapper.MapFromDomain(getCustomer);
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                
                //check if the Product you want to add exist.
                var existingCustomer = _dbContext.Customer.Find(customer.ID);

                if (existingCustomer != null)
                {
                    throw new ArgumentException("Customer with the same ID already exists!");
                } 

                //If not create here a new Product
                _dbContext.Customer.Add(customer);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
                throw;

            }
            return customer;

        }

        //TOOD: Return the updated and previous data of the Customer
        public Customer UpdateCustomer(Customer customer)
        {
            //check if the user exist you want to update.
            var existingCustomer = _dbContext.Customer.Find(customer.ID);
            if (existingCustomer != null)
            {
                _dbContext.Entry(existingCustomer).CurrentValues.SetValues(customer);
                _dbContext.SaveChanges();
            }

            return existingCustomer;
        }

        public Customer DeleteCustomerByID(int id)
        {
            //check if the user exist you want to delete by ID.
            var deletedCustomer = _dbContext.Customer.Find(id);
            if (deletedCustomer != null)
            {
                _dbContext.Customer.Remove(deletedCustomer);
                _dbContext.SaveChanges();
            }

            return deletedCustomer;
        }
    }
}
