using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static List<Order> _orders = new()
        {
            new Order { Id = 1, ProductId = 1, Quantity = 2, CustomerName = "Alice" },
            new Order { Id = 2, ProductId = 2, Quantity = 1, CustomerName = "Bob" }
        };

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() 
            => Ok(_orders);

        // GET: api/Order/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            if (order == null)
                return BadRequest();

            order.Id = _orders.Count > 0 ? _orders.Max(o => o.Id) + 1 : 1;
            _orders.Add(order);

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            _orders.Remove(order);
            return NoContent();
        }
    }
}
