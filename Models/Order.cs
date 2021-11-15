using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {       
        public int OrderID { get; set; }  

        public DateTime OrderDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
