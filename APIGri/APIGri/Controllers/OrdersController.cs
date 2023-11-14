using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIGri.DBModel;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace APIGri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly SrezGriContext _context;

        public OrdersController(SrezGriContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Orders.ToListAsync();
        }
        // Метод для добавления данных
        [HttpPost]
        public IActionResult AddData(Order newData)
        {
            _context.Add(newData);
            return Ok("Данные успешно добалены");
        }
        // Метод для изменения данных
        [HttpPut("{id}")]
        public IActionResult UpdateData(int id, Order updatedData)
        {
            var existingData = _context.Orders.Update(updatedData);
            if (existingData == null)
            {
                return NotFound();
            }
            _context.Update(id);
            return Ok("Data updated successfully");
        }
        // Метод для удаления данных
        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            var existingData = _context.Remove(id);
            if (existingData == null)
            {
                return NotFound();
            }
            _context.Remove(id);
            return Ok("Data deleted successfully");
        }
        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
