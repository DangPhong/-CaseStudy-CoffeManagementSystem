using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.BillDetail
{
    public class BillDetails
    {
        [Display(Name = "Mã CTHD")]
        public int ID { get; set; }
        [Display(Name = "Mã Hóa Đơn")]
        public int BillID { get; set; }
        [Display(Name = "Hóa Món")]
        public int ProductID { get; set; }
        [Display(Name = "Số Lượng")]
        public int Number { get; set; }
        [Display(Name = "Thành Tiền")]
        public decimal Price { get; set; }
        [Display(Name = "Tổng Tiền")]
        public decimal Total { get; set; }
    }
}
