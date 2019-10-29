using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Account
{
    public class AccountDelete
    {
        [Display(Name = "Mã Tài Khoản")]
        public int Id { get; set; }
    }
}
