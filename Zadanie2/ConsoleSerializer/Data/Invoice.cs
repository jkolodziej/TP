using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    [XmlRoot("Invoice")]
    public class Invoice : Transaction, ISerializable
    {
        public decimal ShippingCost { get; set; }
        public decimal TotalPrice { get; set; }

        public Invoice () { }

        public Invoice(Client client, List<ShoesPair> shoesPairs, int count, decimal shippingCost) : base(client, shoesPairs, count)
        {
            ShippingCost = shippingCost;
            TotalPrice = CalculateTotalPrice();
        }

        protected Invoice(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ShippingCost = info.GetDecimal("ShippingCost");
            TotalPrice = info.GetDecimal("TotalPrice");
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
                Invoice i = (Invoice)obj;
                return this.Client.Equals(i.Client) && this.ShoesPairs.Equals(i.ShoesPairs)
                    && this.TotalPrice.Equals(i.TotalPrice) && this.ShippingCost.Equals(i.ShippingCost)
                    && this.Date.Equals(i.Date);
            }
        }

        private decimal CalculateTotalPrice()
        {
            decimal price = 0;
            foreach (ShoesPair shoesPair in ShoesPairs)
            {
                price += (shoesPair.NettoPrice + shoesPair.NettoPrice * shoesPair.Tax);
            }
       
            price += ShippingCost;
            return price;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString()
                 + "\nShipping cost: " + ShippingCost + "\nTotal price: " + TotalPrice;
        }


        public new void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            //info.AddValue("Client", Client);
            //info.AddValue("ShoesPair", ShoesPair);
            //info.AddValue("Count", Count);
            //info.AddValue("Date", Date);
            info.AddValue("ShippingCost", ShippingCost);
            info.AddValue("TotalPrice", TotalPrice);
        }

    }
}
