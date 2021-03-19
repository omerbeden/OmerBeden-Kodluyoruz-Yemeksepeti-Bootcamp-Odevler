using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Part4.Data.Contexts;
using Part4.Data.Entities;
using Part4.Data.Responses;
using Part4.Extensions;
using Part4.Services.Abstract;

namespace Part4.Services.Concrete
{
    public class OrderService:IOrderService
    {
        private DatabaseContext _dbContext;
        private ICustomerService _customerService;

        public OrderService(DatabaseContext dbContext, ICustomerService customerService)
        {
            _dbContext = dbContext;
            _customerService = customerService;
        }


        public List<OrderResponse> GetAll()
        {
            var orders = _dbContext.Orders.ToList();
            var customers = _customerService.GetAll();

            return orders.ToOrderResponses(customers);


        }

        public OrderResponse GetById(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(o => o.OrderId == id);
            var customerResponse = _customerService.GetById(order.CustomerId);

            return order.ToOrderResponse(customerResponse);
        }

        public void Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return false;
            }

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            
            return true;
        }
    }
}
