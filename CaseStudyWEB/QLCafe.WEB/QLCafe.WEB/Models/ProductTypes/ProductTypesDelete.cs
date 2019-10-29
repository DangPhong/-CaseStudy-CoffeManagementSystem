using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Models.ProductTypes
{
    public class ProductTypesDelete
    {
        [Display(Name = "Mã Loại Món")]
        public int Id { get; set; }
    }
}
