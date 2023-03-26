using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Model.Models
{
    public class Allocation
    {
        public Guid AllocationID { get; set; }
        public Guid ProductID { get; set; }
        public Product? Product { get; set; }
        public Guid BinID { get; set; }
        public Bin? Bin { get; set; }
        public decimal Quantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
