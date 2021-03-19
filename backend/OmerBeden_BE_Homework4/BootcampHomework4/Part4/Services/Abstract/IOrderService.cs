using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part4.Data.Entities;
using Part4.Data.Responses;

namespace Part4.Services.Abstract
{
    public interface IOrderService
    {

        List<OrderResponse> GetAll();
        OrderResponse GetById(int id);
        void Add(Order order);
        bool Delete(int id);

    }
}
