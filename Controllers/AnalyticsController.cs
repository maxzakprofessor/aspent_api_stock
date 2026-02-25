using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkladProject.Data;
using SkladProject.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace SkladProject.Controllers;

[Route("api")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly AppDbContext _context;
    public AnalyticsController(AppDbContext context) { 
        _context = context; 
        QuestPDF.Settings.License = LicenseType.Community;
    }

    private async Task<List<BalanceDto>> CalculateBalances()
    {
        var inc = await _context.Goodincomes.Include(i => i.Stocks).Include(i => i.Goods).ToListAsync();
        var mov = await _context.Goodmoves.Include(m => m.StocksFrom).Include(m => m.StocksTo).Include(m => m.Goods).ToListAsync();
        var balances = new Dictionary<(string, string), int>();

        foreach (var i in inc) {
            var k = (i.Stocks?.NameStock ?? "!", i.Goods?.NameGood ?? "!");
            balances[k] = balances.GetValueOrDefault(k) + i.qty;
        }
        foreach (var m in mov) {
            var kF = (m.StocksFrom?.NameStock ?? "!", m.Goods?.NameGood ?? "!");
            var kT = (m.StocksTo?.NameStock ?? "!", m.Goods?.NameGood ?? "!");
            balances[kF] = balances.GetValueOrDefault(kF) - m.qty;
            balances[kT] = balances.GetValueOrDefault(kT) + m.qty;
        }
        return balances.Select(b => new BalanceDto { NameStock = b.Key.Item1, NameGood = b.Key.Item2, Qty = b.Value }).ToList();
    }

    [HttpGet("goodrests/{wStock}/{wGood}")]
    public async Task<IActionResult> GetBalances(string wStock, string wGood) {
        var res = await CalculateBalances();
        // ПРИМЕНЯЕМ ОБА ФИЛЬТРА (Как в твоем Django проекте) [INDEX]
        if (wStock != "All") res = res.Where(r => r.NameStock == wStock).ToList();
        if (wGood != "All") res = res.Where(r => r.NameGood == wGood).ToList();
        return Ok(res);
    }

    [HttpPost("goodrests/{wStock}/{wGood}")]
    public async Task<IActionResult> GetPdf(string wStock, string wGood)
    {
        var data = await CalculateBalances();
        if (wStock != "Все") data = data.Where(r => r.NameStock == wStock).ToList();
        if (wGood != "Все") data = data.Where(r => r.NameGood == wGood).ToList();

        var pdf = Document.Create(container => {
            container.Page(page => {
                page.Margin(50);
                page.Header().Text($"Отчет по остаткам: {wStock} / {wGood}").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
                page.Content().Table(table => {
                    table.ColumnsDefinition(columns => { columns.RelativeColumn(); columns.RelativeColumn(); columns.ConstantColumn(80); });
                    foreach (var item in data) {
                        table.Cell().Text(item.NameStock);
                        table.Cell().Text(item.NameGood);
                        table.Cell().Text(item.Qty.ToString());
                    }
                });
            });
        }).GeneratePdf();

        return File(pdf, "application/pdf", "Report.pdf");
    }

    [HttpGet("dashboard/stats")]
    public async Task<IActionResult> GetDashboard() {
        var res = await CalculateBalances();
        return Ok(new {
            cards = new { goods = await _context.Goods.CountAsync(), stocks = await _context.Stocks.CountAsync(), operations = await _context.Goodincomes.CountAsync() },
            chart = new { labels = res.Select(r => r.NameGood).Take(5), datasets = new[] { new { label = "Остатки", data = res.Select(r => r.Qty).Take(5) } } }
        });
    }
}

public class BalanceDto { public string NameStock { get; set; } = ""; public string NameGood { get; set; } = ""; public int Qty { get; set; } }
