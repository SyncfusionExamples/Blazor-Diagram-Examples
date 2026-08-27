using Diagram_MySQL.Server.Data;
using Diagram_MySQL.Server.Models;
using LinqToDB;
using LinqToDB.Async;
using Microsoft.AspNetCore.Mvc;

namespace Diagram_MySQL.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagramController : ControllerBase
    {
        private readonly AppDataConnection _db;
        public DiagramController(AppDataConnection db) => _db = db;

        [HttpGet("items")]
        public async Task<IActionResult> GetItems()
        {
            var items = await _db.Employees.ToListAsync();
            return Ok(items);
        }
    }
}