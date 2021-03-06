using System;
using System.Collections.Generic;

#nullable disable

namespace CakeBaker.Models
{
    public partial class CakeDetail
    {
        public CakeDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CakeId { get; set; }
        public string CakeName { get; set; }
        public string CakeDescription { get; set; }
        public double? CakePrice { get; set; }
        public int? CakeQuantity { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
