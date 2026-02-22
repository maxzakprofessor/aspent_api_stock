namespace SkladProject.Models;
public class Goodincomes {
    public int Id { get; set; }
    // Имена теперь точно как в твоем Serializer: stock и good
    public int stock { get; set; } 
    public virtual Stocks? Stocks { get; set; }
    public int good { get; set; }
    public virtual Goods? Goods { get; set; }
    public int qty { get; set; }
    public DateTime datetime { get; set; } = DateTime.UtcNow;
}
