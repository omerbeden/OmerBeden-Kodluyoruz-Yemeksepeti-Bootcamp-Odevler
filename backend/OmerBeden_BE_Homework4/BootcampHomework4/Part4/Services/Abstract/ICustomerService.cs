using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part4.Data.Entities;
using Part4.Data.Responses;

namespace Part4.Services.Abstract
{
    public interface ICustomerService
    {

        List<CustomerResponse> GetAll();
        CustomerResponse GetById(int id);

        void Add(Customer customer);
    }
}
