using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.BillDetail
{
    public class BillDetailAdd
    {
        [Display(Name = "Mã Hóa Đơn")]
        [Required]
        public int BillID { get; set; }
        [Display(Name = "Mã Món")]
        [Required]
        public int ProductID { get; set; }
        [Display(Name = "Số Lượng")]
        [Required(ErrorMessage = "Bạn phải Nhập Số Lượng")]
        public int Number { get; set; }
    }
}
