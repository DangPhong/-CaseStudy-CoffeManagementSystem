using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLCafe.Domain.Response
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Data { get; set; }
        public string TypeName { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
    }
}
