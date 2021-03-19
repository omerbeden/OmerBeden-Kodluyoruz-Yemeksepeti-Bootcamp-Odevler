using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Part4.Data.Contexts;
using Part4.Data.Entities;
using Part4.Data.Responses;
using Part4.Services.Abstract;

namespace Part4.Services.Concrete
{
    public class CustomerService : ICustomerService
    {

        private DatabaseContext _databaseContext;

        public CustomerService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<CustomerResponse> GetAll()
        {
            var customers = _databaseContext.Customers.ToList();
            return customers.Adapt<List<CustomerResponse>>();
        }

        public CustomerResponse GetById(int id)
        {
            var customer = _databaseContext.Customers.SingleOrDefault(c => c.CustomerId == id);
            return customer.Adapt<CustomerResponse>();
            
        }

        public void Add(Customer customer)
        {
            _databaseContext.Customers.Add(customer);
            _databaseContext.SaveChanges();
        }
    }
}
