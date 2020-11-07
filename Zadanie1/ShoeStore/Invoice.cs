using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoeStore
{
    class Invoice
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public ShoesDetail ShoesDetail { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingCost { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }

        public Invoice(Guid id, Client client, ShoesDetail shoesDetail, decimal shippingCost, DateTimeOffset purchaseDate)
        {
            Id = id;
            Client = client;
            ShoesDetail = shoesDetail;
            TotalPrice = ShoesDetail.Price * ShoesDetail.Discount + ShippingCost;
            ShippingCost = shippingCost;
            PurchaseDate = purchaseDate;
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
    }
}
