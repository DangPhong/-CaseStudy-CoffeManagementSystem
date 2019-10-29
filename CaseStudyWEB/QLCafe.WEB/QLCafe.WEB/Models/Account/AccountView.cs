using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Account
{
    public class AccountView
    {
        [Display(Name = "Mã Tài Khoản")]
        public int Id { get; set; }

        [Display(Name = "Tên Đăng Nhập")]
        public string UserName { get; set; }

        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [Display(Name = "Vai Trò")]
        public int Role { get; set; }
    }
}
