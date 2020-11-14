using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Entities;
using ShoeStore.Fillers;
using System;
using System.Linq;

namespace ShoeStore.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        private DataRepository dataRepository;
        private ConstantFiller constantFiller;

        public DataRepositoryTests()
        {
            constantFiller = new ConstantFiller();
            dataRepository = new DataRepository(constantFiller);
        }

        [TestMethod()]
        public void AddShoesTest()
        {
            // valid argument 
            Shoes shoes1 = new Shoes("VA11", 41, "Vans", Shoes.SexEnum.Unisex);
            dataRepository.AddShoes(shoes1);
            Assert.AreEqual(6, dataRepository.GetAllShoes().Count());
            Assert.AreEqual(shoes1, dataRepository.GetAllShoes().Last());

            // argument exception
            Shoes shoes2 = new Shoes("NI30", 45, "Nike", Shoes.SexEnum.Male);
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddShoes(shoes2));
        }

        [TestMethod()]
        public void GetShoesTest()
        {
            // valid argument
            Shoes shoes = new Shoes("AD79", 38, "Adidas", Shoes.SexEnum.Female);
            Assert.AreEqual(shoes, dataRepository.GetShoes(112));

            // argument exception
            Assert.ThrowsException<ArgumentException>(() => dataRepository.GetShoes(1111));
        }

        [TestMethod()]
        public void GetAllShoesTest()
        {
            Assert.AreEqual(5, dataRepository.GetAllShoes().Count());
        }

        [TestMethod()]
        public void UpdateShoesTest()
        {
            // valid argument
            Shoes shoes = new Shoes("NI40", 45, "Nike", Shoes.SexEnum.Male);
            dataRepository.UpdateShoes(113, shoes);
            Assert.AreEqual("NI40", dataRepository.GetShoes(113).ShoesModel);

            // argument exception
            Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateShoes(1111, shoes));
        }

        [TestMethod()]
        public void DeleteShoesTest()
        {
            // valid argument
            dataRepository.DeleteShoes(112);
            Assert.AreEqual(4, dataRepository.GetAllShoes().Count());

            // argument exception
            Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteShoes(1111));
        }

        [TestMethod()]
        public void AddClientTest()
        {
            // valid argument 
            Client client1 = new Client("Hermenegilda", "Kowalska", "hermenegilda.kowalska@gmail.com", "Łódź Piotrkowska 35", "+48123123123");
            dataRepository.AddClient(client1);
            Assert.AreEqual(6, dataRepository.GetAllClients().Count());
            Assert.AreEqual(client1, dataRepository.GetAllClients().Last());

            // argument exception
            Client client2 = new Client("Zofia", "Nowak", "zofia.nowak@gmail.com", "Pabianice Zamkowa 23c", "+48123456782");
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddClient(client2));
        }

        [TestMethod()]
        public void GetClientTest()
        {
            // valid argument
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            Assert.AreEqual(client, dataRepository.GetClient(0));

            // argument exception
            Assert.ThrowsException<ArgumentException>(() => dataRepository.GetClient(1111));
        }

        [TestMethod()]
        public void GetAllClientsTest()
        {
            Assert.AreEqual(5, dataRepository.GetAllClients().Count());
        }

        [TestMethod()]
        public void UpdateClientTest()
        {
            // valid argument
            Client client = new Client("Katarzyna", "Kowalska", "katarzyna.kowalska@gmail.com", "Pabianice Zamkowa 23b", "+48111222333");
            dataRepository.UpdateClient(client);
            Assert.AreEqual("+48111222333", dataRepository.GetClient(1).PhoneNumber);

            // argument exception
            Assert.ThrowsException<ArgumentException>(() => 
                    dataRepository.UpdateClient(new Client("Hermenegilda", "Kowalska", "hermenegilda.kowalska@gmail.com", "Łódź Piotrkowska 35", "+48123123123")));
        }

        [TestMethod()]
        public void DeleteClientTest()
        {
            // valid argument
            dataRepository.DeleteClient(new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780"));
            Assert.AreEqual(4, dataRepository.GetAllClients().Count());

            // argument exception
            Assert.ThrowsException<ArgumentException>(() =>
                    dataRepository.DeleteClient(new Client("Hermenegilda", "Kowalska", "hermenegilda.kowalska@gmail.com", "Łódź Piotrkowska 35", "+48123123123")));
        }

        [TestMethod()]
        public void AddTransactionTest()
        {
            // valid argument 
            Transaction transaction1 = new Invoice(dataRepository.GetClient(0), dataRepository.GetShoesPair(3), 1, new decimal(12.0));
            dataRepository.AddTransaction(transaction1);
            Assert.AreEqual(7, dataRepository.GetAllTransactions().Count());
            Assert.AreEqual(transaction1, dataRepository.GetAllTransactions().Last());

            // argument exception
            Transaction transaction2 = new Invoice(dataRepository.GetClient(0), dataRepository.GetShoesPair(0), 1, new decimal(12.0));
            transaction2.SetDate(dataRepository.GetTransaction(0).Date);
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddTransaction(transaction2));
        }

        [TestMethod()]
        public void GetTransactionTest()
        {
            // valid argument
            Transaction transaction = new Invoice(dataRepository.GetClient(1), dataRepository.GetShoesPair(1), 1, new decimal(12.0));
            transaction.SetDate(dataRepository.GetTransaction(1).Date);
            Assert.AreEqual(transaction, dataRepository.GetTransaction(1));

            // argument exception
            Assert.ThrowsException<ArgumentException>(() => dataRepository.GetTransaction(1111));
        }

        [TestMethod()]
        public void GetAllTransactionsTest()
        {
            Assert.AreEqual(6, dataRepository.GetAllTransactions().Count());
        }

        [TestMethod()]
        public void UpdateTransactionTest()
        {
            // valid argument
            Transaction transaction1 = new Invoice(dataRepository.GetClient(1), dataRepository.GetShoesPair(1), 2, new decimal(12.0));
            transaction1.SetDate(dataRepository.GetTransaction(1).Date);
            dataRepository.UpdateTransaction(1, transaction1);
            Assert.AreEqual(2, dataRepository.GetTransaction(1).Count);

            // argument exception
            Transaction transaction2 = new Invoice(dataRepository.GetClient(2), dataRepository.GetShoesPair(2), 2, new decimal(12.0));
            Assert.ThrowsException<ArgumentException>(() =>
                    dataRepository.UpdateTransaction(1111, transaction2));
        }

        [TestMethod()]
        public void DeleteTransactionTest()
        {
            // valid argument
            dataRepository.DeleteTransaction(dataRepository.GetTransaction(1));
            Assert.AreEqual(5, dataRepository.GetAllTransactions().Count());

            // argument exception
            Assert.ThrowsException<ArgumentException>(() => 
                    dataRepository.DeleteTransaction(new Invoice(dataRepository.GetClient(4), dataRepository.GetShoesPair(2), 2, new decimal(12.0))));
        }

        [TestMethod()]
        public void IncreaseStockCountTest()
        {
            Transaction transaction = new Return(dataRepository.GetClient(0), dataRepository.GetShoesPair(0), 2);
            dataRepository.IncreaseStockCount(dataRepository.GetShoesPair(0), transaction);
            Assert.AreEqual(22, dataRepository.GetShoesPair(0).StockCount);
        }

        [TestMethod()]
        public void DecreaseStockCountTest()
        {
            Transaction transaction = new Invoice(dataRepository.GetClient(0), dataRepository.GetShoesPair(0), 5, new decimal(12.0));
            dataRepository.DecreaseStockCount(dataRepository.GetShoesPair(0), transaction);
            Assert.AreEqual(15, dataRepository.GetShoesPair(0).StockCount);
        }

        [TestMethod()]
        public void AddShoesPairTest()
        {
            // valid argument 
            ShoesPair shoesPair1 = new ShoesPair(dataRepository.GetShoes(114), new decimal(450.0),
                            new decimal(0.22), 10, new decimal(0.2));
            dataRepository.AddShoesPair(shoesPair1);
            Assert.AreEqual(7, dataRepository.GetAllShoesPairs().Count());
            Assert.AreEqual(shoesPair1, dataRepository.GetAllShoesPairs().Last());

            // argument exception
            ShoesPair shoesPair2 = new ShoesPair(dataRepository.GetShoes(111), new decimal(300.0),
                            new decimal(0.22), 20, new decimal(0.1));
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddShoesPair(shoesPair2));
        }

        [TestMethod()]
        public void GetShoesPairTest()
        {
            // valid argument
            ShoesPair shoesPair = new ShoesPair(dataRepository.GetShoes(111), new decimal(300.0),
                            new decimal(0.22), 20, new decimal(0.1));
            Assert.AreEqual(shoesPair, dataRepository.GetShoesPair(0));

            // argument exception
            Assert.ThrowsException<ArgumentException>(() => dataRepository.GetShoesPair(1111));
        }

        [TestMethod()]
        public void GetAllShoesPairsTest()
        {
            Assert.AreEqual(6, dataRepository.GetAllShoesPairs().Count());
        }

        [TestMethod()]
        public void UpdateShoesPairTest()
        {
            // valid argument
            ShoesPair shoesPair = new ShoesPair(dataRepository.GetShoes(111), new decimal(300.0),
                            new decimal(0.22), 30, new decimal(0.1));
            dataRepository.UpdateShoesPair(0, shoesPair);
            Assert.AreEqual(30, dataRepository.GetShoesPair(0).StockCount);

            // argument exception
            Assert.ThrowsException<ArgumentException>(() =>
                    dataRepository.UpdateShoesPair(1111, shoesPair));
        }

        [TestMethod()]
        public void DeleteShoesPairTest()
        {
            // valid argument
            dataRepository.DeleteShoesPair(new ShoesPair(dataRepository.GetShoes(111), new decimal(300.0),
                            new decimal(0.22), 20, new decimal(0.1)));
            Assert.AreEqual(5, dataRepository.GetAllShoesPairs().Count());

            // argument exception
            Assert.ThrowsException<ArgumentException>(() =>
                    dataRepository.DeleteShoesPair(new ShoesPair(dataRepository.GetShoes(111), new decimal(300.0),
                            new decimal(0.22), 40, new decimal(0.1))));
        }
    }
}