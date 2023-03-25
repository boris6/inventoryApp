using System.ComponentModel.DataAnnotations;
using InventoryApp.Model.Enums;

namespace InventoryApp.Model.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Code is a required field")]
        public string Code { get;set; }
        [Required(ErrorMessage = "Description is a required field")]
        public string Description { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public decimal Price { get; set; }
        public decimal NominalWeight { get; set; }
        public User CreatedBy { get; set; }     
    }
}