using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Bills
{
    public class TableCoffee
    {
        [Display(Name = "Mã Bàn")]
        public int ID { get; set; }

        [Display(Name = "Tên Bàn")]
        public string Name { get; set; }

        [Display(Name = "Trạng Thái")]
        public int Status { get; set; }
    }
}
