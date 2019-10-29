using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.TableCoffees
{
    public class TableCoffeesDetail
    {
        [Display(Name = "Mã Bàn")]
        public int ID { get; set; }

        [Display(Name = "Khu Vực")]
        public string Area { get; set; }

        [Display(Name = "Tên Bàn")]
        public string Name { get; set; }

        [Display(Name = "Trạng Thái")]
        public string StrStatus { get; set; }
    }
}
