using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public ShoesDetail ShoesDetail { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingCost { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }

        public Invoice(Guid id, Client client, ShoesDetail shoesDetail, int count, decimal shippingCost, DateTimeOffset purchaseDate)
        {
            Id = id;
            Client = client;
            ShoesDetail = shoesDetail;
            Count = Count;
            ShippingCost = shippingCost;
            TotalPrice = calculateTotalPrice();
            PurchaseDate = purchaseDate;
        }

        private decimal calculateTotalPrice()
        {
            decimal price = ShoesDetail.Discount * (ShoesDetail.NettoPrice + ShoesDetail.NettoPrice * ShoesDetail.Tax);
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
                return this.Id.Equals(i.Id) && this.Client.Equals(i.Client) &&
                       this.ShoesDetail.Equals(i.ShoesDetail) && this.TotalPrice.Equals(i.TotalPrice) && 
                       this.ShippingCost.Equals(i.ShippingCost) && this.PurchaseDate.Equals(i.PurchaseDate);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
