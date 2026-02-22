using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkladProject.Data;
using SkladProject.Models;

namespace SkladProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GoodincomesController : ControllerBase
{
    private readonly AppDbContext _context;
    public GoodincomesController(AppDbContext context) { _context = context; }

    [HttpGet]
    public async Task<IActionResult> GetIncomes() {
        var data = await _context.Goodincomes.Include(i => i.Stocks).Include(i => i.Goods)
            .Select(i => new {
                id = i.Id,
                stock = i.stock,
                good = i.good,
                nameStock = i.Stocks != null ? i.Stocks.NameStock : "",
                nameGood = i.Goods != null ? i.Goods.NameGood : "",
                qty = i.qty,
                datetime = i.datetime
            }).ToListAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> PostIncome(Goodincomes inc) {
        inc.Stocks = null; inc.Goods = null;
        _context.Goodincomes.Add(inc);
        await _context.SaveChangesAsync();
        return Ok(inc);
    }

    // ИСПРАВЛЕНО: Один маршрут. .NET сам уберет лишний слеш из запроса Vue.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutIncome(int id, Goodincomes inc) {
        var existing = await _context.Goodincomes.FindAsync(id);
        if (existing == null) return NotFound();

        existing.stock = inc.stock;
        existing.good = inc.good;
        existing.qty = inc.qty;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIncome(int id) {
        var income = await _context.Goodincomes.FindAsync(id);
        if (income == null) return NotFound();
        _context.Goodincomes.Remove(income);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
