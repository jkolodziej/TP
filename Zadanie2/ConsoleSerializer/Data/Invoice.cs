﻿using System;
using System.Runtime.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    public class Invoice : Transaction, ISerializable
    {
        public decimal ShippingCost { get; set; }
        public decimal TotalPrice { get; set; }

        public Invoice(Client client, ShoesPair shoesPair, int count, decimal shippingCost) : base(client, shoesPair, count)
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
                return this.Client.Equals(i.Client) && this.ShoesPair.Equals(i.ShoesPair)
                    && this.TotalPrice.Equals(i.TotalPrice) && this.ShippingCost.Equals(i.ShippingCost)
                    && this.Date.Equals(i.Date);
            }
        }

        private decimal CalculateTotalPrice()
        {
            decimal price = (ShoesPair.NettoPrice + ShoesPair.NettoPrice * ShoesPair.Tax);
            price -= price * ShoesPair.Discount;
            price *= Count;
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
