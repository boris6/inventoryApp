namespace InventoryApp.Model.Models;

public class Bin
{
    public Guid BinID { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal MaximumCapacity { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public IList<Allocation> Allocations { get; set; } = new List<Allocation>();
}