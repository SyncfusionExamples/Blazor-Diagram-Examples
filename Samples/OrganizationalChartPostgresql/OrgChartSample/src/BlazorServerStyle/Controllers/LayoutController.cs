using BlazorServerStyle.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorServerStyle.Models;

namespace BlazorServerStyle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LayoutController : ControllerBase
{
    private readonly AppDbContext _context;

    public LayoutController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<LayoutNode>>> Get()
    {
        try
        {
            return await _context.OrgChartLayouts.OrderBy(n => n.Id).ToListAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
