using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Unit
{
    public class UnitView
    {
        [Display(Name = "Mã DVT")]
        public int Id { get; set; }

        [Display(Name = "Đơn Vị Tính")]
        public string Name { get; set; }
    }
}
