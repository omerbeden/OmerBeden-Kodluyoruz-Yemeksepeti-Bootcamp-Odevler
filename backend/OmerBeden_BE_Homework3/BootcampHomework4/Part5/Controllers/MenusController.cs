using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part5.Data.Entities;
using Part5.Services.Abstract;

namespace Part5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var menus = _menuService.GetAll();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var menu = _menuService.GetById(id);
            return Ok(menu);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Menu menu)
        {
            _menuService.Add(menu);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _menuService.Delete(new Menu { Id = id });
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Menu menu,int id)
        {
            _menuService.Update(id,menu);
            return Ok();
        }
        
        
        
    }
}
