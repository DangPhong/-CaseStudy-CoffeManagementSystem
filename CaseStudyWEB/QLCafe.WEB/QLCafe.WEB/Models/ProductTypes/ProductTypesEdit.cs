using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.ProductTypes
{
    public class ProductTypesEdit
    {
        [Display(Name = "Mã Loại Món")]
        public int ID { get; set; }

        [Display(Name = "Loại Món")]
        [Required(ErrorMessage = "Bạn phải nhập Tên Loại Món")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Tên Loại Sản Phẩm phải lớn hơn {2} ký tự và không quá {1} ký tự")]
        public string Name { get; set; }
    }
}
