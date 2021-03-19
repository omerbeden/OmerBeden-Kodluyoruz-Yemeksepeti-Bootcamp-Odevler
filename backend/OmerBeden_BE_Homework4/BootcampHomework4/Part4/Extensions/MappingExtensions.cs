using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part4.Data.Entities;
using Part4.Data.Responses;

namespace Part4.Extensions
{
    public static class MappingExtensions
    {
        public static List<OrderResponse> ToOrderResponses(this List<Order> orders, List<CustomerResponse> customerResponses)
        {
            List<OrderResponse> orderResponses = new List<OrderResponse>();

            if (orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    orderResponses.Add(new OrderResponse
                    {
                        Customer = customerResponses[i],
                        OrderDate = orders[i].OrderDate,
                        OrderId = orders[i].OrderId,
                        ShipAdress = orders[i].ShipAdress,
                        ShipName = orders[i].ShipName
                    });
                }
            }

            return orderResponses;
        }


        public static OrderResponse ToOrderResponse(this Order order, CustomerResponse customerResponse)
        {
            return new OrderResponse
            {
                Customer = customerResponse,
                OrderDate = order.OrderDate,
                OrderId = order.OrderId,
                ShipAdress = order.ShipAdress,
                ShipName = order.ShipName
            };
        }
    }
}
