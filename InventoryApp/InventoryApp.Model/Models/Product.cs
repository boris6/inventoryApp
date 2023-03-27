using System.ComponentModel.DataAnnotations;
using InventoryApp.Model.Enums;

namespace InventoryApp.Model.Models
{
    public class Product
    {
        public Guid ProductID { get; set; }
        [Required(ErrorMessage = "Code is a required field")]
        [StringLength(10)]
        public string Code { get;set; }
        [Required(ErrorMessage = "Description is a required field")]
        [StringLength(30)]
        public string Description { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public decimal Price { get; set; }
        public decimal NominalWeight { get; set; }
        public string CreatedBy { get; set; }
        public IList<Allocation> Allocations { get; set; } = new List<Allocation>();
        public string FullName => $"{Code} - {Description}";
    }
}