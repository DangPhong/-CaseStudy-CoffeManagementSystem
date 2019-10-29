using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.TableCoffees
{
    public class TableCoffeesCreate
    {
        [Display(Name ="Khu Vực")]
        [Required(ErrorMessage = "Bạn phải nhập Khu Vực")]
        public int AreaID { get; set; }

        [Display(Name = "Tên Bàn")]
        [Required(ErrorMessage = "Bạn phải nhập Tên Bàn")]
        [StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "Tên Bàn phải lớn hơn {2} ký tự và không quá {1} ký tự")]
        public string Name { get; set; }
    }
}
