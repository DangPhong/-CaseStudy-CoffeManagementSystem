using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.TableCoffees
{
    public class TableCoffeesDelete
    {
        [Display(Name = "Mã Bàn")]
        public int ID { get; set; }
    }
}
