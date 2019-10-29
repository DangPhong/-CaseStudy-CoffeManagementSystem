using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Products
{
    public class ProductsUpdate
    {
        [Display(Name = "Mã Món")]
        public int Id { get; set; }

        [Display(Name = "Tên Món")]
        [Required(ErrorMessage = "Bạn phải nhập Tên Món")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Tên Món phải lớn hơn {2} ký tự và không quá {1} ký tự")]
        public string Name { get; set; }

        [Display(Name = "Thể loại món")]
        [Column(TypeName = "varchar(MAX)")]
        public string Data { get; set; }
        public int TypeID { get; set; }

        [Display(Name = "Đơn vị Tính")]
        public int UnitID { get; set; }

        [Display(Name = "Thành Tiền")]
        [Required(ErrorMessage = "Bạn phải nhập Thành Tiền")]
        [Range(1000, 60000, ErrorMessage = "Thành Tiền của Món chỉ nằm trong khoản {1} đồng và không quá {2} đồng")]
        public decimal Price { get; set; }
    }
}
