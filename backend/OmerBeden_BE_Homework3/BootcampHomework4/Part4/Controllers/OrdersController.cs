using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part4.Data.Entities;
using Part4.Data.Responses;
using Part4.Services.Abstract;

namespace Part4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;


        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var orderResponses = _orderService.GetAll();
            return Ok(orderResponses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var orderResponses = _orderService.GetAll();
            return Ok(orderResponses);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            bool result = _orderService.Delete(id);

            return result ? (IActionResult)Ok() : BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] Order order)
        {
            _orderService.Add(order);
            return Ok();
        }


    }
}
