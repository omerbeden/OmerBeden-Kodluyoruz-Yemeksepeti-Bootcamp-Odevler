using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Part5.Data.Entities;
using Part5.Services.Abstract;

namespace Part5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _restaurantService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var result = _restaurantService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Restaurant restaurant)
        {
             _restaurantService.Add(restaurant);
             return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Restaurant restaurant,int id)
        {
            _restaurantService.Update(id,restaurant);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _restaurantService.Delete(new Restaurant{Id = id});
            return Ok();
        }
    }
}
