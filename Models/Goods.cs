using System.ComponentModel.DataAnnotations;
namespace SkladProject.Models;
public class Goods { public int Id { get; set; } [Required] [StringLength(500)] public string NameGood { get; set; } = string.Empty; }
