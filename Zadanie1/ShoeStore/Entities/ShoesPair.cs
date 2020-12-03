using System;

namespace ShoeStore.Data
{
    public class ShoesPair
    {
        public Shoes Shoes { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal Tax { get; set; }
        public int StockCount { get; set; }
        public decimal Discount { get; set; }

        public ShoesPair(Shoes shoes, decimal nettoPrice, decimal tax, int stockCount, decimal discount)
        {
            Shoes = shoes;
            NettoPrice = nettoPrice;
            Tax = tax;
            StockCount = stockCount;
            Discount = discount;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ShoesPair i = (ShoesPair)obj;
                return this.Shoes.Equals(i.Shoes) && this.NettoPrice.Equals(i.NettoPrice)
                    && this.StockCount.Equals(i.StockCount) && this.Discount.Equals(i.Discount)
                    && this.Tax.Equals(i.Tax);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
