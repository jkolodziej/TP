using System;
using System.Runtime.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    public class ShoesPair : ISerializable
    {
        public Shoes Shoes { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal Tax { get; set; }
        public int StockCount { get; set; }
        public decimal Discount { get; set; }

        public ShoesPair() { }

        public ShoesPair(Shoes shoes, decimal nettoPrice, decimal tax, int stockCount, decimal discount)
        {
            Shoes = shoes;
            NettoPrice = nettoPrice;
            Tax = tax;
            StockCount = stockCount;
            Discount = discount;
        }

        protected ShoesPair(SerializationInfo info, StreamingContext context)
        {
            Shoes = info.GetValue("Shoes", typeof(Shoes)) as Shoes;
            NettoPrice = info.GetDecimal("NettoPrice");
            Tax = info.GetDecimal("Tax");
            StockCount = info.GetInt32("StockCount");
            Discount = info.GetDecimal("Discount");
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

        public override string ToString()
        {
            return "\nShoes: " + Shoes.ToString() + "\nNetto price: " + NettoPrice
                 + "\nTax: " + Tax + "\nStock count: " + StockCount
                 + "\nDiscount: " + Discount;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Shoes", Shoes);
            info.AddValue("NettoPrice", NettoPrice);
            info.AddValue("Tax", Tax);
            info.AddValue("StockCount", StockCount);
            info.AddValue("Discount", Discount);
        }
    }
}
