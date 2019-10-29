using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCafe.WEB.Models.Products
{
    public class Products
    {
        public int ID { get; set; }
        [Display(Name="Tên Món")]
        [Required(ErrorMessage ="Bạn phải nhập tên Món")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        [Display(Name = "Hình ảnh")]
        public string Data { get; set; }
        [Display(Name = "Thể loại Món")]
        public string TypeName { get; set; }
        [Display(Name = "Đơn Vị Tính")]
        public string UnitName { get; set; }
        [Display(Name = "Thành Tiền")]
        public decimal Price { get; set; }
    }
}
