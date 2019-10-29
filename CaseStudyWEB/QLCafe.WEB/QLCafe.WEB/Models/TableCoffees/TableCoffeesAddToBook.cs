using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.TableCoffees
{
    public class TableCoffeesAddToBook
    {
        [Display(Name = "Mã Bàn")]
        [Required]
        public int TableID { get; set; }

        [Display(Name = "Ngày Đặt")]
        [Required]
        public DateTime DateTimeCheckIn { get; set; }

        [Display(Name = "Tên Người Đặt")]
        [Required(ErrorMessage = "Bạn phải nhập Tên Người Đặt")]
        public string CustomerName { get; set; }

        [Display(Name = "SĐT Người Đặt")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        [RegularExpression(pattern: "(09|01[2689]){1}([0-9]{8})", ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string CustomerPhone { get; set; }
    }
}
