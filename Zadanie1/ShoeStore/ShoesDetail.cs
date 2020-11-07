using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    public class ShoesDetail
    {
        public Guid Id { get; set; }
        public Shoes Shoes { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal Discount { get; set; }

        public ShoesDetail(Guid id, Shoes shoes, decimal price, int count, decimal discount)
        {
            Id = id;
            Shoes = shoes;
            Price = price;
            Count = count;
            Discount = discount;
        }
    }
}
