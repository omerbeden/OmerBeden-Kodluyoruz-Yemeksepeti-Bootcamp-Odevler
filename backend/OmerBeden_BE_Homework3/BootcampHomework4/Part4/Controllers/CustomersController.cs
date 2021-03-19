using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Part4.Data.Entities;
using Part4.Data.Responses;
using Part4.Services.Abstract;

namespace Part4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomerResponse),StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var responses = _customerService.GetAll();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomerResponse),StatusCodes.Status404NotFound)]
        public IActionResult GetByID(int id)
        {
            var reponse = _customerService.GetById(id);
            return Ok(reponse);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] Customer customer)
        {
            _customerService.Add(customer);
            return Ok();
        }
    }
}
