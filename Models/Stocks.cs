using System.ComponentModel.DataAnnotations;
namespace SkladProject.Models;
public class Stocks { public int Id { get; set; } [Required] [StringLength(500)] public string NameStock { get; set; } = string.Empty; }
