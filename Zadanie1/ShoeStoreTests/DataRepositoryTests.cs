using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore;
using ShoeStore.Fillers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        private DataRepository dataRepository;
        private ConstantFiller constantFiller;

        public DataRepositoryTests(IDataFiller dataFiller)
        {
            ConstantFiller constantFiller = new ConstantFiller();
            DataRepository dataRepository = new DataRepository(constantFiller);
        }

        [TestMethod()]
        public void AddShoesTest()
        {
            //
        }

        [TestMethod()]
        public void GetShoesTest()
        {
            //
        }

        [TestMethod()]
        public void getAllShoesTest()
        {
            //
        }

        [TestMethod()]
        public void UpdateShoesTest()
        {
            //
        }

        [TestMethod()]
        public void DeleteShoesTest()
        {
            //
        }

        [TestMethod()]
        public void AddClientTest()
        {
            //
        }

        [TestMethod()]
        public void GetClientTest()
        {
            //
        }

        [TestMethod()]
        public void getAllClientsTest()
        {
            //
        }

        [TestMethod()]
        public void UpdateClientTest()
        {
            //
        }

        [TestMethod()]
        public void DeleteClientTest()
        {
            //
        }

        [TestMethod()]
        public void AddTransactionTest()
        {
            //
        }

        [TestMethod()]
        public void GetTransactionTest()
        {
            //
        }

        [TestMethod()]
        public void getAllTransactionsTest()
        {
            //
        }

        [TestMethod()]
        public void UpdateTransactionTest()
        {
            //
        }

        [TestMethod()]
        public void DeleteTransactionTest()
        {
            //
        }

        [TestMethod()]
        public void IncreaseStockCountTest()
        {
            //
        }

        [TestMethod()]
        public void DecreaseStockCountTest()
        {
            //
        }

        [TestMethod()]
        public void AddShoesPairTest()
        {
            //
        }

        [TestMethod()]
        public void GetShoesPairTest()
        {
            //
        }

        [TestMethod()]
        public void getAllShoesPairsTest()
        {
            //
        }

        [TestMethod()]
        public void UpdateShoesPairTest()
        {
            //
        }

        [TestMethod()]
        public void DeleteShoesPairTest()
        {
            //
        }
    }
}