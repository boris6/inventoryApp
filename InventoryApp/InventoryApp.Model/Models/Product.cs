using InventoryApp.Model.Enums;

namespace InventoryApp.Model.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Code { get;set; }
        public string Description { get; set; }
        public int UnitOfMeasure { get; set; }
        public decimal Price { get; set; }
        public decimal NominalWeight { get; set; }
        public User CreatedBy { get; set; }     
    }
}