using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Models
{
    [Table("Orders")]
    public class Order : IEntity
    {
        [Key]
        public int OrderID { get; set; }  

        public DateTime OrderDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
