using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Part5.Data.Entities;
using Part5.Services.Abstract;

namespace Part5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private IDrinkService _drinkService;

        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _drinkService.GetAll();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            _drinkService.GetById(id);
            return Ok();
        }

        [HttpPost]
        public void Add([FromBody] Drink drink)
        {
            _drinkService.Add(drink);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Drink drink,int id)
        {
            _drinkService.Update(id,drink);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _drinkService.Delete(new Drink{Id = id});
            return Ok();
        }
    }
}
