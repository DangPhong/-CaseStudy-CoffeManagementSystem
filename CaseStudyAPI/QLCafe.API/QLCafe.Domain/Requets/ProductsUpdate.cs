using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLCafe.Domain.Requets
{
    public class ProductsUpdate
    {   
        public int Id { get; set; }
        public int TypeID { get; set; }
        public int UnitID { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Data { get; set; }
        public decimal Price { get; set; }
    }
}
