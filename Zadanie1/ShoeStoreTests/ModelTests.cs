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
            Guid id = Guid.NewGuid();
            Address address = new Address("Pabianice", "Zamkowa", "23b");
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com",address,"+48123456789");
            Assert.AreEqual("Jan", client.Name);
            Assert.AreEqual("Kowalski", client.Surname);
            Assert.AreEqual("jan.kowalski@gmail.com", client.EmailAddress);
            Assert.AreEqual(address, client.Address);
            Assert.AreEqual("+48123456789", client.PhoneNumber); 
        }


    }
}
