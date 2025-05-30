using Microsoft.AspNetCore.Mvc;
using PhoneAPI.models;

namespace PhoneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> _products = new();
        private static int _nextId = 1;

        [HttpGet(Name = ("GetALL"))]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_products);

        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPost()]
        public ActionResult<Product> Create(CreateProductModel product)
        {
            var newProduct = new Product();
            newProduct.Id = _nextId++;
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.Status = product.Status;
            _products.Add(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int Id, CreateProductModel Updated)
        {
            var product = _products.FirstOrDefault(p => p.Id == Id);
            if (product == null)
                return NotFound();

            product.Name = Updated.Name;
            product.Price = Updated.Price;
            product.Status = Updated.Status;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            _products.Remove(product);
            return NoContent();
        }
    }
}
