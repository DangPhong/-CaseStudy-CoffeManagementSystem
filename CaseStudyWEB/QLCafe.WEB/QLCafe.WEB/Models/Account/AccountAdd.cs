using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Account
{
    public class AccountAdd
    {
        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage = "Bạn phải nhập Tên Đăng Nhập")]
        [StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "Tên Khu Vực phải lớn hơn 3 ký tự")]
        public string UserName { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập Mật Khẩu")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Mật Khẩu phải lớn hơn {2} ký tự và không quá {1}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Vai Trò")]
        [Required]
        public int Role { get; set; }
    }
}
