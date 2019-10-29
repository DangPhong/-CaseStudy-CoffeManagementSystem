using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCafe.WEB.Models.Products
{
    public class ProductsDetail
    {
        [Display(Name = "Mã Món")]
        public int ID { get; set; }
        [Display(Name="Tên món")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Data { get; set; }
        [Display(Name = "Thể loại món")]
        public string TypeName { get; set; }
        [Display(Name = "Đơn vị Tính")]
        public string UnitName { get; set; }
        [Display(Name = "Thành Tiền")]
        public decimal Price { get; set; }
    }
}
