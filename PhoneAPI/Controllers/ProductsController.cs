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


        

    }
}
