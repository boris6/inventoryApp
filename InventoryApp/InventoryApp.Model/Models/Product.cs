using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Model.Models;

public class Product
{
    public Guid ProductID { get; set; }

    [Required(ErrorMessage = "Code is a required field")]
    [StringLength(10)]
    public string Code { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is a required field")]
    [StringLength(30)]
    public string Description { get; set; } = string.Empty;

    [Range(0, int.MaxValue)] public decimal Price { get; set; }
    [Range(0, int.MaxValue)] public decimal Weight { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public IList<Allocation> Allocations { get; set; } = new List<Allocation>();
    public string FullName => $"{Code} - {Description} - {Weight} kg";
}