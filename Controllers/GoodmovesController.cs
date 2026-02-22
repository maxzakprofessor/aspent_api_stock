using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkladProject.Data;
using SkladProject.Models;

namespace SkladProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GoodmovesController : ControllerBase
{
    private readonly AppDbContext _context;
    public GoodmovesController(AppDbContext context) { _context = context; }

    [HttpGet]
    public async Task<IActionResult> GetMoves() {
        var data = await _context.Goodmoves.Include(m => m.StocksFrom).Include(m => m.StocksTo).Include(m => m.Goods)
            .Select(m => new {
                id = m.Id,
                qty = m.qty,
                datetime = m.datetime,
                stockFrom = m.stockFrom,
                nameStockFrom = m.StocksFrom != null ? m.StocksFrom.NameStock : "",
                stockTo = m.stockTo,
                nameStockTowhere = m.StocksTo != null ? m.StocksTo.NameStock : "",
                good = m.good,
                nameGood = m.Goods != null ? m.Goods.NameGood : ""
            }).ToListAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> PostMove(Goodmoves move) {
        move.StocksFrom = null; move.StocksTo = null; move.Goods = null;
        _context.Goodmoves.Add(move);
        await _context.SaveChangesAsync();
        return Ok(move);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMove(int id, Goodmoves move) {
        var existing = await _context.Goodmoves.FindAsync(id);
        if (existing == null) return NotFound();
        existing.stockFrom = move.stockFrom;
        existing.stockTo = move.stockTo;
        existing.good = move.good;
        existing.qty = move.qty;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
