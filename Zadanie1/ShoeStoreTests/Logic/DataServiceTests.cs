using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Entities;
using ShoeStore.Fillers;
using System;
using System.Collections;
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
            int numberOfInvoices = dataService.GetAllInvoices().Count();
            dataService.BuyShoes(dataRepository.GetClient(1), dataRepository.GetShoesPair(1), 1, 
                            new decimal(12.0), DateTimeOffset.Now);
            Assert.AreEqual(numberOfInvoices + 1, dataService.GetAllInvoices().Count());
        }

        [TestMethod]
        public void ReturnShoesTest()
        {
            
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
            Assert.AreEqual(6, dataService.GetAllInvoices().Count());
        }

        [TestMethod]
        public void GetAllInvoicesForClientTest()
        {
           Client client = dataRepository.GetClient(0);
           Invoice invoice1 = dataRepository.GetInvoice(0);
           Invoice invoice2= dataRepository.GetInvoice(5);
           CollectionAssert.AreEqual(new List<Invoice> { invoice1, invoice2 }, dataService.GetAllInvoicesForClient(client).ToList());
        }

        [TestMethod]
        public void GetAllInvoicesBetweenTest()
        {
            //
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