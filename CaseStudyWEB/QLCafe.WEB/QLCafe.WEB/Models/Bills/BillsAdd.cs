using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Bills
{
    public class BillsAdd
    {
        [Display(Name = "Mã Bàn")]
        [Required]
        public int TableID { get; set; }
    }
}
