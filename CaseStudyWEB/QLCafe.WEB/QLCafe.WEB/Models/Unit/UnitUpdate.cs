using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Unit
{
    public class UnitUpdate
    {
        [Display(Name = "Mã DVT")]
        public int Id { get; set; }
       
        [Display(Name = "Đơn Vị Tính")]
        [Required(ErrorMessage = "Bạn phải nhập Đơn Vị Tính")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Tên Đơn Vị Tính phải lớn hơn {2} ký tự và không quá {1} ký tự")]
        public string Name { get; set; }
    }
}
