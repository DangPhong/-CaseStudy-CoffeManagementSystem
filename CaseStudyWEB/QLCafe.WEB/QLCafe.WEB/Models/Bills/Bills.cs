using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Bills
{
    public class Bills
    {
        [Display(Name = "Mã Hóa Đơn")]
        public int ID { get; set; }
        [Display(Name = "Mã Bàn:")]
        public int TableID { get; set; }
        [Display(Name = "TG Tạo:")]
        public DateTime DateTimeCheckIn { get; set; }
        [Display(Name = "TG Thanh Toán:")]
        public DateTime? DateTimeCheckOut { get; set; }
        [Display(Name = "Tên Người Đặt")]
        public string CustomerName { get; set; }
        [Display(Name = "SDT Người Đặt")]
        public string CustomerPhone { get; set; }
        [Display(Name = "Trạng Thái:")]
        public string StrStatus { get; set; }
        public bool HasBillDetails { get; set; }
    }
}
