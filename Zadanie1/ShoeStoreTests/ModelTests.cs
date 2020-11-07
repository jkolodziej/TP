using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore;
using System;
using System.Drawing;

namespace ShoeStoreTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void ShoesTest()
        {
            // set guid
            Guid id = Guid.NewGuid();

            Shoes shoes = new Shoes(id, "trampki", 39, "Adidas", Color.Aqua, Shoes.SexEnum.Female);

            Assert.AreEqual(id, shoes.Id);
            Assert.AreEqual("trampki", shoes.ShoesType);
            Assert.AreEqual(39, shoes.Size);
            Assert.AreEqual("Adidas", shoes.Brand);
            Assert.AreEqual(Color.Aqua, shoes.Color);
            Assert.AreEqual(Shoes.SexEnum.Female, shoes.Sex);
        }

        [TestMethod]
        public void ClientTest()
        {
            Address address = new Address("Pabianice", "Zamkowa", "23b");
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", address, "+48123456789");

            Assert.AreEqual("Jan", client.Name);
            Assert.AreEqual("Kowalski", client.Surname);
            Assert.AreEqual("jan.kowalski@gmail.com", client.EmailAddress);
            Assert.AreEqual(address, client.Address);
            Assert.AreEqual("+48123456789", client.PhoneNumber); 
        }

        [TestMethod]
        public void ShoesDetailTest()
        {
            Guid id = Guid.NewGuid();

            Shoes shoes = new Shoes(id, "trampki", 39, "Adidas", Color.Aqua, Shoes.SexEnum.Female);
            ShoesDetail shoesDetail = new ShoesDetail(id, shoes, new decimal(300.0),new decimal(0.22),20, new decimal(0.1));

            Assert.AreEqual(id,shoesDetail.Id);
            Assert.AreEqual(shoes,shoesDetail.Shoes);
            Assert.AreEqual(new decimal(300.0),shoesDetail.NettoPrice);
            Assert.AreEqual(new decimal(0.22),shoesDetail.Tax);
            Assert.AreEqual(20,shoesDetail.StockCount);
            Assert.AreEqual(new decimal(0.1),shoesDetail.Discount);
        }

        [TestMethod]
        public void InvoiceTest()
        {
            Guid id = Guid.NewGuid();
            Guid shoesId = Guid.NewGuid();
            Guid shoesDetailId = Guid.NewGuid();

            DateTimeOffset purchaseDate = DateTimeOffset.Now;
            Address address = new Address("Pabianice", "Zamkowa", "23b");
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", address, "+48123456789");
            Shoes shoes = new Shoes(shoesId, "trampki", 39, "Adidas", Color.Aqua, Shoes.SexEnum.Female);
            ShoesDetail shoesDetail = new ShoesDetail(shoesDetailId, shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            Invoice invoice = new Invoice(id, client, shoesDetail, 1, new decimal(12.0), purchaseDate);

            Assert.AreEqual(id, invoice.Id);
            Assert.AreEqual(client, invoice.Client);
            Assert.AreEqual(shoesDetail, invoice.ShoesDetail);
            Assert.AreEqual(1, invoice.Count);
            Assert.AreEqual(new decimal(12.0), invoice.ShippingCost);
            Assert.AreEqual(purchaseDate, invoice.PurchaseDate);

        }

    }
}
