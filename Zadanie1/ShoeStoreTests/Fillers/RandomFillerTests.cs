using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ShoeStore.Fillers;
using ShoeStore;
using System.Linq;

namespace ShoeStoreTests.Fillers
{
    [TestClass]
    public class RandomFillerTests
    {
        private RandomFiller randomFiller;
        private DataContext dataContext;

        public RandomFillerTests()
        {
            this.dataContext = new DataContext();
            this.randomFiller = new RandomFiller(5, 7);
            randomFiller.Fill(dataContext);
        }

        [TestMethod]
        public void FillTest()
        {
            //Assert.AreEqual(5, dataRepository.getAllClients().Count());
            //Assert.AreEqual(7, dataRepository.getAllShoes().Count());
            //Assert.AreEqual(7, dataRepository.getAllShoesPairs().Count());
            //Assert.AreEqual(7, dataRepository.getAllInvoices().Count());
        }
    }
}
