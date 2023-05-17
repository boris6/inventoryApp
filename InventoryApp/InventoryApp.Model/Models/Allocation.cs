using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Model.Models;

public class Allocation
{
    [Key] public Guid AllocationID { get; set; }

    [ForeignKey("ProductID")] public Guid ProductID { get; set; }

    public Product? Product { get; set; }

    [ForeignKey("BinID")] public Guid BinID { get; set; }

    public Bin? Bin { get; set; }

    [Range(0, int.MaxValue)] public decimal Quantity { get; set; }

    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}