using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Entities;
using System;

namespace ShoeStoreTests.Entities
{
    [TestClass]
    public class EntitiesTests
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
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com","Pabianice Zamkowa 23","+48123456789");
            Assert.AreEqual("Jan", client.Name);
            Assert.AreEqual("Kowalski", client.Surname);
            Assert.AreEqual("jan.kowalski@gmail.com", client.EmailAddress);
            Assert.AreEqual("Pabianice Zamkowa 23", client.Address);
            Assert.AreEqual("+48123456789", client.PhoneNumber); 
        }

        [TestMethod]
        public void ShoesPairTest()
        {
            Shoes shoes = new Shoes("XC89", 39, "Adidas", Shoes.SexEnum.Female);
            ShoesPair shoesPair = new ShoesPair(shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));

            Assert.AreEqual(shoes, shoesPair.Shoes);
            Assert.AreEqual(new decimal(300.0), shoesPair.NettoPrice);
            Assert.AreEqual(new decimal(0.22), shoesPair.Tax);
            Assert.AreEqual(20, shoesPair.StockCount);
            Assert.AreEqual(new decimal(0.1), shoesPair.Discount);
        }

        [TestMethod]
        public void TransactionTest()
        {
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23b", "+48123456789");
            Shoes shoes = new Shoes("XC89", 39, "Adidas", Shoes.SexEnum.Female);
            ShoesPair shoesPair = new ShoesPair(shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            Transaction invoice = new Invoice(client, shoesPair, 1, new decimal(12.0));

            Assert.AreEqual(client, invoice.Client);
            Assert.AreEqual(shoesPair, invoice.ShoesPair);
            Assert.AreEqual(1, invoice.Count);
        }
    }
}
