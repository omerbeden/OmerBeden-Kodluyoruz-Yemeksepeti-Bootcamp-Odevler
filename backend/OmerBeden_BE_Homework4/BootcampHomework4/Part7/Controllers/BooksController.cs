using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Part7.Data.Contexts;

namespace Part7.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class BooksController : ControllerBase
    {
        private DatabaseContext _databaseContext;

        public BooksController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult GetAll()
        {
            var books = _databaseContext.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.1")]
        public IActionResult GetById(int id)
        {
            var book = _databaseContext.Books.Find(id);
            return Ok(book);
        }
    }
}
