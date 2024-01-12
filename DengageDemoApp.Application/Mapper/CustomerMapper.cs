using DengageDemoApp.Contract.Model;
using DengageDemoApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengageDemoApp.Application.Mapper
{
    public static class CustomerMapper
    {
        public static CustomerModel MapFromDomain(Customer customer)
        {
            return new CustomerModel
            {
                ID = customer.ID,
                name = customer.name,
                gender = customer.gender,
                phonenumber = customer.phonenumber,
                createdAt = customer.createdAt,
                createdBy = customer.createdBy,
                updatedAt = customer.updatedAt,
                updatedBy = customer.updatedBy,
            };
        }
    }
}
