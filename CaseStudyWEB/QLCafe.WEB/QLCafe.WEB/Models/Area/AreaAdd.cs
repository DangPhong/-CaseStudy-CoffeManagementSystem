using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QLCafe.WEB.Models
{
    public class AreaAdd
    {
        [Display(Name = "Tên Khu Vực")]
        [Required(ErrorMessage = "Bạn phải nhập Tên Khu Vực")]
        [StringLength(maximumLength: 10, MinimumLength = 5, ErrorMessage = "Tên Khu Vực phải lớn hơn {2} ký tự và nhỏ hơn {1} ký tự")]
        public string Name { get; set; }
    }
}
