using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.BillDetail
{
    public class BillDetailsViewAll
    {
        [Display(Name = "Mã HD")]
        public int ID { get; set; }
        public int BillsDetailID { get; set; }
        public int TableID { get; set; }
        [Display(Name = "TG Gọi Món")]
        public DateTime DateTimeCheckIn { get; set; }
        [Display(Name = "TG Thanh Toán")]
        public DateTime? DateTimeCheckOut { get; set; }
        [Display(Name = "Tên món")]
        public string Name { get; set; }
        [Display(Name = "Số Lượng")]
        public int Number { get; set; }
        [Display(Name = "Thành Tiền")]
        public decimal Price { get; set; }
        [Display(Name = "Tổng Tiền")]
        public decimal Total { get; set; }
        [Display(Name = "Tổng Thanh Toán")]
        public decimal SumTotal { get; set; }
        [Display(Name = "Trạng Thái")]
        public string StrStatus { get; set; }
    }
}
