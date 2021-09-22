namespace Models
{
    public class OrderDetail
    {
        public string ProductName { get; set; }

        public Product Products { get; set; }

        public int OrderID { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double Discount { get; set; }
    }
}
