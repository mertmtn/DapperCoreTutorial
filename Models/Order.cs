using System;

namespace Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public string ProductName { get; set; }

        public Product Products { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public OrderDetail OrderDetails { get; set; }
    }
}
