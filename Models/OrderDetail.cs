namespace Models
{
    public class OrderDetail
    { 
        public int OrderID { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double Discount { get; set; }
    }
}
