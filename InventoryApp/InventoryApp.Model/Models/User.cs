using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Model.Models
{
    public class User
    {
        public int UsertId { get; set; }
        [Required(ErrorMessage = "UserName is a required field")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is a required field")]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
