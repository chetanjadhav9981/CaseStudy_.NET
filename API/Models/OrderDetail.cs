using System;
using System.Collections.Generic;

#nullable disable

namespace CakeBaker.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int? CakeId { get; set; }
        public int? UserId { get; set; }
        public int? CakeQuantity { get; set; }
        public int? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual CakeDetail Cake { get; set; }
        public virtual UserDetail User { get; set; }
    }
}
