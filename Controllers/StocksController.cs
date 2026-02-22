using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkladProject.Data;
using SkladProject.Models;

namespace SkladProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StocksController : ControllerBase
{
    private readonly AppDbContext _context;
    public StocksController(AppDbContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Stocks>>> GetStocks() => await _context.Stocks.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Stocks>> PostStocks(Stocks stock)
    {
        _context.Stocks.Add(stock);
        await _context.SaveChangesAsync();
        return Ok(stock);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStocks(int id, Stocks stock)
    {
        // 1. Находим существующую запись в базе (БЕЗ отслеживания для чистоты)
        var existingStock = await _context.Stocks.FindAsync(id);
        
        if (existingStock == null) return NotFound("Склад не найден");

        // 2. Обновляем только нужные поля
        existingStock.NameStock = stock.NameStock;

        try {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
            return BadRequest("Ошибка при сохранении данных");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null) return NotFound();
        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
