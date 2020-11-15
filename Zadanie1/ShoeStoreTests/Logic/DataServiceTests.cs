using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Entities;
using ShoeStore.Fillers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoeStore.Logic.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        private IDataFiller constantFiller;
        private IDataRepository dataRepository;
        private IDataService dataService; 

        public DataServiceTests()
        {
            constantFiller = new ConstantFiller();
            dataRepository = new DataRepository(constantFiller);
            dataService = new DataService(dataRepository);
        }

        [TestMethod]
        public void AddShoesTest()
        {
            int numberOfShoes = dataService.GetAllShoes().Count();
            dataService.AddShoes("MA67", 40, "Dr. Martens", Shoes.SexEnum.Unisex);
            Assert.AreEqual(numberOfShoes + 1, dataService.GetAllShoes().Count());
        }

        [TestMethod]
        public void AddClientTest()
        {
            int numberOfClients = dataService.GetAllClients().Count();
            dataService.AddClient("Jan", "Nowak", "jan.nowak@gmail.com", "Pabianice Łaska 49", "+48274636363");
            Assert.AreEqual(numberOfClients + 1, dataService.GetAllClients().Count());
        }

        [TestMethod]
        public void AddShoesPairTest()
        {
            int numberOfShoesPairs = dataService.GetAllShoesPairs().Count();
            dataService.AddShoesPair(dataService.GetShoes(112), new decimal(300.0),
                            new decimal(0.22), 20, new decimal(0.1));
            Assert.AreEqual(numberOfShoesPairs + 1, dataService.GetAllShoesPairs().Count());
        }

        [TestMethod]
        public void BuyShoesTest()
        {
            //valid argument
            int numberOfTransactions = dataService.GetAllTransactions().Count();
            dataService.BuyShoes(dataService.GetClient(1), dataService.GetShoesPair(1), 1, new decimal(12.0));

            Assert.AreEqual(numberOfTransactions + 1, dataService.GetAllTransactions().Count());
            Assert.AreEqual(19, dataService.GetShoesPair(1).StockCount);

            //argument exception           
            Assert.ThrowsException<ArgumentException>(() => 
                    dataService.BuyShoes(dataService.GetClient(1), dataService.GetShoesPair(0), 100, new decimal(12.0)));
        }

        [TestMethod]
        public void ReturnShoesTest()
        {
            int numberOfTransactions = dataService.GetAllTransactions().Count();
            dataService.ReturnShoes(dataService.GetShoesPair(3), dataService.GetTransaction(3));

            Assert.AreEqual(numberOfTransactions, dataService.GetAllTransactions().Count());
            Assert.AreEqual(21, dataService.GetShoesPair(3).StockCount);
        }

        [TestMethod]
        public void GetAllShoesTest()
        {
            Assert.AreEqual(5, dataService.GetAllShoes().Count());
        }

        [TestMethod]
        public void GetAllClientsTest()
        {
            Assert.AreEqual(5, dataService.GetAllClients().Count());
        }

        [TestMethod]
        public void GetAllShoesPairsTest()
        {
            Assert.AreEqual(6, dataService.GetAllShoesPairs().Count());
        }

        [TestMethod]
        public void GetAllInvoicesTest()
        {
            Assert.AreEqual(6, dataService.GetAllTransactions().Count());
        }

        [TestMethod]
        public void GetAllTransactionsForClient()
        {
            Client client = dataService.GetClient(0);
            Transaction transaction1 = dataService.GetTransaction(0);
            Transaction transaction2 = dataService.GetTransaction(5);
            CollectionAssert.AreEqual(new List<Transaction> { transaction1, transaction2 }, dataService.GetAllTransactionsForClient(client).ToList());
        }

        [TestMethod]
        public void GetAllInvoicesBetweenTest()
        {
            Transaction transaction1 = dataService.GetTransaction(1);
            transaction1.Date = DateTimeOffset.Now.Subtract(new TimeSpan(0, 50, 0));
            Transaction transaction2 = dataService.GetTransaction(2);
            transaction2.Date = DateTimeOffset.Now.Subtract(new TimeSpan(0, 45, 0));
            Transaction transaction3 = dataService.GetTransaction(3);
            transaction3.Date = DateTimeOffset.Now.Subtract(new TimeSpan(0, 40, 0));
            DateTimeOffset startDate = DateTimeOffset.Now.Subtract(new TimeSpan(1, 0, 0));
            DateTimeOffset endDate = DateTimeOffset.Now.Subtract(new TimeSpan(0,30,0));

            CollectionAssert.AreEqual(new List<Transaction> { transaction1, transaction2, transaction3 },
                        dataService.GetAllInvoicesBetween(startDate, endDate).ToList());
        }

        [TestMethod]
        public void GetListOfShoesTest()
        {
            List<string> listOfShoes = dataService.GetListOfShoes();

            Assert.AreEqual(5, dataService.GetListOfShoes().Count());
            Assert.AreEqual("Shoes model: AD89\nSize: 39\nBrand: Adidas\nSex: Female", listOfShoes[0]);
        }

        [TestMethod()]
        public void GetShoesTest()
        {
            Shoes shoes = new Shoes("AD79", 38, "Adidas", Shoes.SexEnum.Female);
            Assert.AreEqual(shoes, dataService.GetShoes(112));
        }

        [TestMethod()]
        public void GetShoesPairTest()
        {
            ShoesPair shoesPair = new ShoesPair(dataService.GetShoes(111), new decimal(300.0),
                            new decimal(0.22), 20, new decimal(0.1));
            Assert.AreEqual(shoesPair, dataService.GetShoesPair(0));
        }

        [TestMethod()]
        public void GetTransactionTest()
        {
            Transaction transaction = new Invoice(dataService.GetClient(1), dataService.GetShoesPair(1), 1, new decimal(12.0))
            {
                Date = dataService.GetTransaction(1).Date
            };
            Assert.AreEqual(transaction, dataRepository.GetTransaction(1));
        }

        [TestMethod()]
        public void GetClientTest()
        {
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            Assert.AreEqual(client, dataService.GetClient(0));
        }
    }
}