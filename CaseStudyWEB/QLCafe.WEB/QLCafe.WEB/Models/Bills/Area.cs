using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.Bills
{
    public class Area
    {
        [Display(Name = "Mã Khu Vực")]
        public int ID { get; set; }

        [Display(Name = "Khu Vực")]
        public string Name { get; set; }
    }
}
