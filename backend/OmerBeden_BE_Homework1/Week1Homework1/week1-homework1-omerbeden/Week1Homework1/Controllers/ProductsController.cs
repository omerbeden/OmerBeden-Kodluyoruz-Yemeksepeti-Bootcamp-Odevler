using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Week1Homework1.Data_Access;

using Week1Homework1.Entity;

namespace Week1Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDal _productDal;

        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }



        [HttpGet]
        public List<Product> Get()
        {
            return _productDal.GetList();
        }


        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productDal.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _productDal.Add(product);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _productDal.Update(id, product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

    }
}
