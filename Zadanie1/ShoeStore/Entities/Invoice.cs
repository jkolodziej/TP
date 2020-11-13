using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Entities
{
    public class Invoice
    {
        public Client Client { get; set; }
        public ShoesPair ShoesPair { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingCost { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }

        public Invoice(Client client, ShoesPair shoesPair, int count, decimal shippingCost, DateTimeOffset purchaseDate)
        {
            Client = client;
            ShoesPair = shoesPair;
            Count = count;
            ShippingCost = shippingCost;
            TotalPrice = CalculateTotalPrice();
            PurchaseDate = purchaseDate;
        }

        private decimal CalculateTotalPrice()
        {
            decimal price = (ShoesPair.NettoPrice + ShoesPair.NettoPrice * ShoesPair.Tax);
            price -= price * ShoesPair.Discount;
            price *= Count;
            price += ShippingCost;
            return price;
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
                    && this.PurchaseDate.Equals(i.PurchaseDate);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
