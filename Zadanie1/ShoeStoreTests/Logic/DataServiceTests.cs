using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Logic;
using ShoeStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore.Logic.Tests
{
    [TestClass()]
    public class DataServiceTests
    {
        [TestMethod()]
        public void AddShoesTest()
        {
            ConstantFiller constantFiller = new ConstantFiller();
            DataRepository dataRepository = new DataRepository(constantFiller);
            DataService dataService = new DataService(dataRepository);
            int numberOfShoes = dataService.GetAllShoes().Count();
            dataService.AddShoes("MA67", 40, "Dr. Martens", Shoes.SexEnum.Unisex);
            Assert.AreEqual(numberOfShoes + 1, dataService.GetAllShoes().Count());
        }

        [TestMethod()]
        public void AddClientTest()
        {
            ConstantFiller constantFiller = new ConstantFiller();
            DataRepository dataRepository = new DataRepository(constantFiller);
            DataService dataService = new DataService(dataRepository);
            int numberOfClients = dataService.GetAllClients().Count();
            dataService.AddClient("Jan", "Nowak", "jan.nowak@gmail.com", "Pabianice Łaska 49", "+48274636363");
            Assert.AreEqual(numberOfClients + 1, dataService.GetAllClients().Count());
        }

        [TestMethod()]
        public void AddShoesPairTest()
        {
            
        }

        [TestMethod()]
        public void BuyShoesTest()
        {
            
        }

        [TestMethod()]
        public void ReturnShoesTest()
        {
            
        }

        [TestMethod()]
        public void GetAllShoesTest()
        {
            
        }

        [TestMethod()]
        public void GetAllClientsTest()
        {
          
        }

        [TestMethod()]
        public void GetAllShoesPairsTest()
        {
            
        }

        [TestMethod()]
        public void GetAllInvoicesTest()
        {
            //
        }

        [TestMethod()]
        public void GetAllInvoicesForClientTest()
        {
            //ConstantFiller constantFiller = new ConstantFiller();
            //DataRepository dataRepository = new DataRepository(constantFiller);
            //DataService dataService = new DataService(dataRepository);
            //Shoes shoes1 = new Shoes("XC89", 39, "Adidas", Shoes.SexEnum.Female);
            //Shoes shoes2 = new Shoes("XC89", 38, "Adidas", Shoes.SexEnum.Female);
            //dataRepository.AddShoes(shoes1);
            //dataRepository.AddShoes(shoes2);
           
            //Client client = new Client("Jan", "Kowal", "jan.kowal@gmail.com", "Pabianice Zamkowa 23b", "+48123456789");
            //dataRepository.AddClient(client);
            //Guid shoesPairId1 = Guid.NewGuid();
            //Guid shoesPairId2 = Guid.NewGuid();
            //Guid invoiceId1 = Guid.NewGuid();
            //Guid invoiceId2 = Guid.NewGuid();
            //DateTimeOffset purchaseDate = DateTimeOffset.Now;
            //ShoesPair shoesPair1 = new ShoesPair(shoesPairId1, shoes1, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            //ShoesPair shoesPair2 = new ShoesPair(shoesPairId2, shoes2, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            //dataRepository.AddShoesPair(shoesPair1);
            //dataRepository.AddShoesPair(shoesPair2);
            //Invoice invoice1 = new Invoice(invoiceId1, client, shoesPair1, 1, new decimal(12.0), purchaseDate);
            //Invoice invoice2 = new Invoice(invoiceId2, client, shoesPair2, 1, new decimal(12.0), purchaseDate);
            //dataService.BuyShoes(invoiceId1, client, shoesPair1, 1, new decimal(12.0), purchaseDate);
            //dataService.BuyShoes(invoiceId2, client, shoesPair2, 1, new decimal(12.0), purchaseDate);

            //List<Invoice> clientInvoices = dataService.GetAllInvoicesForClient(client).ToList();
            //CollectionAssert.AreEqual(new List<Invoice> { invoice1, invoice2 }, clientInvoices);
            //Assert.AreEqual(2, dataService.GetAllInvoices().Count());
        }

        [TestMethod()]
        public void GetAllInvoicesBetweenTest()
        {
            //
        }

        [TestMethod()]
        public void GetListOfShoesTest()
        {
            //
        }
    }
}