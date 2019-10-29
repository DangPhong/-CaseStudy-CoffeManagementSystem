using System;
using System.Collections.Generic;
using System.Text;

namespace QLCafe.Domain.Requets
{
    public class TableCoffeesAddToBook
    {
        public int TableID { get; set; }
        public DateTime DateTimeCheckIn { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
    }
}
