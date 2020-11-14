using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Entities;
using System.Linq;

namespace ShoeStore.Fillers.Tests
{
    [TestClass]
    public class RandomFillerTests
    {
        private RandomFiller randomFiller;
        private DataRepository dataRepository;

        public RandomFillerTests()
        {
            this.randomFiller = new RandomFiller(5, 7);
            this.dataRepository = new DataRepository(randomFiller);
        }

        [TestMethod]
        public void FillTest()
        {
            Assert.AreEqual(5, dataRepository.GetAllClients().Count());
            Assert.AreEqual(7, dataRepository.GetAllShoes().Count());
            Assert.AreEqual(7, dataRepository.GetAllShoesPairs().Count());
            Assert.AreEqual(7, dataRepository.GetAllTransactions().Count());
        }

        [TestMethod]
        public void GenPhoneNumberTest()
        {
            string number = randomFiller.GenPhoneNumber();
            Assert.AreEqual(9, number.Length);
        }

        [TestMethod]
        public void GenEmailSignTest()
        {
            string sign = randomFiller.GenEmailSign();
            Assert.IsFalse(sign.IndexOfAny(new char[] { '*', '_', '-', '.' }) == -1);
        }

        [TestMethod]
        public void CreateShoesTest()
        {
            Shoes created = randomFiller.CreateShoes();

            Assert.IsFalse(created.Brand == null);
            Assert.IsFalse(created.ShoesModel == null);
            Assert.IsTrue(created.Size >= 18 && created.Size <= 45);
        }

        [TestMethod]
        public void CreateClientTest()
        {
            Client created = randomFiller.CreateClient();

            Assert.IsFalse(created.Address == null);
            Assert.IsFalse(created.EmailAddress == null);
            Assert.IsFalse(created.Name == null);
            Assert.IsFalse(created.PhoneNumber == null);
            Assert.IsFalse(created.Surname == null);
        }

        [TestMethod]
        public void CreateShoesPairTest()
        {
            Shoes shoes = randomFiller.CreateShoes();
            ShoesPair created = randomFiller.CreateShoesPair(shoes);

            Assert.IsTrue(created.Discount <= new decimal(0.75) && created.Discount >= new decimal(0.0));
            Assert.IsTrue(created.NettoPrice <= new decimal(500) && created.NettoPrice >= new decimal(50));
            Assert.IsFalse(created.Shoes == null);
            Assert.IsTrue(created.StockCount >= 10 && created.StockCount <= 1000);
            Assert.AreEqual(created.Tax, new decimal(0.22));
        }

        [TestMethod]
        public void CreateInvoiceTest()
        {
            Shoes shoes = randomFiller.CreateShoes();
            ShoesPair shoesPair = randomFiller.CreateShoesPair(shoes);
            Client client = randomFiller.CreateClient();
            Transaction created = randomFiller.CreateInvoice(client, shoesPair);

            Assert.IsFalse(created.Client == null);
            Assert.IsFalse(created.ShoesPair == null);
            Assert.AreEqual(created.Count, 1);
            Assert.IsFalse(created.Date == null);
        }
    }
}
