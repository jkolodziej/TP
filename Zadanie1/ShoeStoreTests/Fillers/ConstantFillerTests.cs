using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Fillers;
using ShoeStore;
using System.Linq;

namespace ShoeStore.Fillers.Tests
{
    [TestClass()]
    public class ConstantFillerTests
    {
        private ConstantFiller constantFiller;
        private DataRepository dataRepository;

        [TestMethod()]
        public void FillTest()
        {
            constantFiller = new ConstantFiller();
            dataRepository = new DataRepository(constantFiller);

            Assert.AreEqual(5, dataRepository.getAllClients().Count());
            Assert.AreEqual(5, dataRepository.getAllShoes().Count());
            Assert.AreEqual(6, dataRepository.getAllShoesPairs().Count());
            Assert.AreEqual(6, dataRepository.getAllInvoices().Count());
        }
    }
}