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
        public Product Product { get; set; }
        public Bin Bin { get; set; }
        public decimal Quantity { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
