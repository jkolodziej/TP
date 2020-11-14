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
        private ConstantFiller constantFiller;
        private DataRepository dataRepository;
        private DataService dataService; 

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
            dataService.AddShoesPair(dataRepository.GetShoes(112), new decimal(300.0),
                            new decimal(0.22), 20, new decimal(0.1));
            Assert.AreEqual(numberOfShoesPairs + 1, dataService.GetAllShoesPairs().Count());
        }

        [TestMethod]
        public void BuyShoesTest()
        {
            int numberOfTransactions = dataService.GetAllTransactions().Count();
            dataService.BuyShoes(dataRepository.GetClient(1), dataRepository.GetShoesPair(1), 1, new decimal(12.0));
            Assert.AreEqual(numberOfTransactions + 1, dataService.GetAllTransactions().Count());
            Assert.AreEqual(19, dataRepository.GetShoesPair(1).StockCount);
        }

        [TestMethod]
        public void ReturnShoesTest()
        {
            int numberOfTransactions = dataService.GetAllTransactions().Count();
            dataService.ReturnShoes(dataRepository.GetShoesPair(3), dataRepository.GetTransaction(3));
            Assert.AreEqual(numberOfTransactions, dataService.GetAllTransactions().Count());
            Assert.AreEqual(21, dataRepository.GetShoesPair(3).StockCount);
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
            Client client = dataRepository.GetClient(0);
            Transaction transaction1 = dataRepository.GetTransaction(0);
            Transaction transaction2 = dataRepository.GetTransaction(5);
            CollectionAssert.AreEqual(new List<Transaction> { transaction1, transaction2 }, dataService.GetAllTransactionsForClient(client).ToList());
        }

        [TestMethod]
        public void GetAllInvoicesBetweenTest()
        {
            Transaction transaction1 = dataRepository.GetTransaction(1);
            transaction1.SetDate(DateTimeOffset.Now.Subtract(new TimeSpan(0, 50, 0)));
            Transaction transaction2 = dataRepository.GetTransaction(2);
            transaction2.SetDate(DateTimeOffset.Now.Subtract(new TimeSpan(0, 45, 0)));
            Transaction transaction3 = dataRepository.GetTransaction(3);
            transaction3.SetDate(DateTimeOffset.Now.Subtract(new TimeSpan(0, 40, 0)));
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
    }
}