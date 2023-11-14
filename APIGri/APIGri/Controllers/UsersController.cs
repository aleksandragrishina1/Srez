using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIGri.DBModel;

namespace APIGri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly SrezGriContext _context;

        public UsersController(SrezGriContext context)
        {
            _context = context;
        }

        // GET: api/UserAutorization
        [HttpGet("/api/Users/Autorization")]
        public async Task<ActionResult<User>> GetUserAutorization(string login, string password)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Login == login && c.Password == password);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }


        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
