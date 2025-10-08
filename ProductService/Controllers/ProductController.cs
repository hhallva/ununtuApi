using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Description = "Gaming laptop" },
            new Product { Id = 2, Name = "Mouse", Price = 29.99m, Description = "Wireless mouse" }
        };

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
            => Ok(_products);

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if (product == null)
                return BadRequest();

            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
    }
}
