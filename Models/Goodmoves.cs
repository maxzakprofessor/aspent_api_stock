namespace SkladProject.Models;
public class Goodmoves {
    public int Id { get; set; }
    public int stockFrom { get; set; }
    public virtual Stocks? StocksFrom { get; set; }
    public int stockTo { get; set; }
    public virtual Stocks? StocksTo { get; set; }
    public int good { get; set; }
    public virtual Goods? Goods { get; set; }
    public int qty { get; set; }
    public DateTime datetime { get; set; } = DateTime.UtcNow;
}
