using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Model.Models
{
    public class Allocation
    {
        [Key]
        public Guid AllocationID { get; set; }
        [ForeignKey("ProductID")]
        public Guid ProductID { get; set; }
        public Product? Product { get; set; }
        [ForeignKey("BinID")]
        public Guid BinID { get; set; }
        public Bin? Bin { get; set; }
        public decimal Quantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
