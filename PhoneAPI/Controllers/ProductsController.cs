using Microsoft.AspNetCore.Mvc;
using PhoneAPI.models;

namespace PhoneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> _products = new ();
        private static int _nextId = 1;

        [HttpGet(Name = ("GetALL"))]
        public ActionResult <IEnumerable<Product>> GetAll()
        {
            return Ok(_products);

        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(itn id)
        {
            var product = _products.FirstOrDefault(p  => p.Id == id);
            if (product == null)
            return NotFound();
            return Ok(product);
        }

    }
}
