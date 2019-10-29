using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models
{
    public class AreaUpdate
    {
        [Display(Name = "Mã Khu Vực")]
        public int ID { get; set; }

        [Display(Name = "Tên Khu Vực")]
        [Required(ErrorMessage = "Bạn phải Nhập Tên Khu Vực")]
        [StringLength(maximumLength: 10, MinimumLength = 5, ErrorMessage = "Tên Khu Vực phải lớn hơn {2} ký tự và nhỏ hơn {1} ký tự")]
        public string Name { get; set; }
    }
}
