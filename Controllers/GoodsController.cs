using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkladProject.Data;
using SkladProject.Models;

namespace SkladProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GoodsController : ControllerBase
{
    private readonly AppDbContext _context;
    public GoodsController(AppDbContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Goods>>> GetGoods() => await _context.Goods.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Goods>> PostGood(Goods good)
    {
        _context.Goods.Add(good);
        await _context.SaveChangesAsync();
        return Ok(good);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGood(int id, Goods good)
    {
        var existingGood = await _context.Goods.FindAsync(id);
        if (existingGood == null) return NotFound();

        existingGood.NameGood = good.NameGood; // Обновляем только имя
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGood(int id)
    {
        var good = await _context.Goods.FindAsync(id);
        if (good == null) return NotFound();
        _context.Goods.Remove(good);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
