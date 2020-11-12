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
    class RandomFillerTests
    {
        private RandomFiller randomFiller;
        private DataRepository dataRepository;

        [TestMethod]
        public void FillTest()
        {
            randomFiller = new RandomFiller(5, 7);
            dataRepository = new DataRepository(randomFiller);

            Assert.AreEqual(5, dataRepository.getAllClients().Count());
            Assert.AreEqual(7, dataRepository.getAllShoes().Count());
            Assert.AreEqual(7, dataRepository.getAllShoesPairs().Count());
            Assert.AreEqual(7, dataRepository.getAllInvoices().Count());
        }

    }
}
