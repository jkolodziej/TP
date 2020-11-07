using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    class ShoesDetail
    {
        private Guid id { get; set; }
        private Shoes shoes { get; set; }
        private decimal price { get; set; }
        private int count { get; set; }
        private decimal discount { get; set; }

        public ShoesDetail(Guid id, Shoes shoes, decimal price, int count, decimal discount)
        {
            this.id = id;
            this.shoes = shoes;
            this.price = price;
            this.count = count;
            this.discount = discount;
        }
    }
}
