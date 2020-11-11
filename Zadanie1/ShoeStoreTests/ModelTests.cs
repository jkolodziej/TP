using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Model;
using System;

namespace ShoeStoreTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void ShoesTest()
        {
            Shoes shoes = new Shoes("XC89", 39, "Adidas", Shoes.SexEnum.Female);

            Assert.AreEqual("XC89", shoes.ShoesModel);
            Assert.AreEqual(39, shoes.Size);
            Assert.AreEqual("Adidas", shoes.Brand);
            Assert.AreEqual(Shoes.SexEnum.Female, shoes.Sex);
        }

        [TestMethod]
        public void ClientTest()
        {
            Address address = new Address("Pabianice", "Zamkowa", "23b");
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com",address,"+48123456789");
            Assert.AreEqual("Jan", client.Name);
            Assert.AreEqual("Kowalski", client.Surname);
            Assert.AreEqual("jan.kowalski@gmail.com", client.EmailAddress);
            Assert.AreEqual(address, client.Address);
            Assert.AreEqual("+48123456789", client.PhoneNumber); 
        }

        [TestMethod]
        public void ShoesPairTest()
        {
            Guid id = Guid.NewGuid();

            Shoes shoes = new Shoes("XC89", 39, "Adidas", Shoes.SexEnum.Female);
            ShoesPair shoesPair = new ShoesPair(id, shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));

            Assert.AreEqual(id, shoesPair.Id);
            Assert.AreEqual(shoes, shoesPair.Shoes);
            Assert.AreEqual(new decimal(300.0), shoesPair.NettoPrice);
            Assert.AreEqual(new decimal(0.22), shoesPair.Tax);
            Assert.AreEqual(20, shoesPair.StockCount);
            Assert.AreEqual(new decimal(0.1), shoesPair.Discount);
        }

        [TestMethod]
        public void InvoiceTest()
        {
            Guid id = Guid.NewGuid();
            Guid shoesPairId = Guid.NewGuid();

            DateTimeOffset purchaseDate = DateTimeOffset.Now;
            Address address = new Address("Pabianice", "Zamkowa", "23b");
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", address, "+48123456789");
            Shoes shoes = new Shoes("XC89", 39, "Adidas", Shoes.SexEnum.Female);
            ShoesPair shoesPair = new ShoesPair(shoesPairId, shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            Invoice invoice = new Invoice(id, client, shoesPair, 1, new decimal(12.0), purchaseDate);

            Assert.AreEqual(id, invoice.Id);
            Assert.AreEqual(client, invoice.Client);
            Assert.AreEqual(shoesPair, invoice.ShoesPair);
            Assert.AreEqual(1, invoice.Count);
            Assert.AreEqual(new decimal(12.0), invoice.ShippingCost);
            Assert.AreEqual(purchaseDate, invoice.PurchaseDate);
        }
    }
}
