using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkladProject.Models;

namespace SkladProject.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Goods> Goods { get; set; }
    public DbSet<Stocks> Stocks { get; set; }
    public DbSet<Goodincomes> Goodincomes { get; set; }
    public DbSet<Goodmoves> Goodmoves { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Маппинг для приходов
        modelBuilder.Entity<Goodincomes>().HasOne(i => i.Stocks).WithMany().HasForeignKey(i => i.stock);
        modelBuilder.Entity<Goodincomes>().HasOne(i => i.Goods).WithMany().HasForeignKey(i => i.good);

        // Маппинг для перемещений
        modelBuilder.Entity<Goodmoves>().HasOne(m => m.StocksFrom).WithMany().HasForeignKey(m => m.stockFrom).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Goodmoves>().HasOne(m => m.StocksTo).WithMany().HasForeignKey(m => m.stockTo).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Goodmoves>().HasOne(m => m.Goods).WithMany().HasForeignKey(m => m.good);
    }
}
