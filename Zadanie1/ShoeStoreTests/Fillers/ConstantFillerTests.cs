using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(5, dataRepository.GetAllClients().Count());
            Assert.AreEqual(5, dataRepository.GetAllShoes().Count());
            Assert.AreEqual(6, dataRepository.GetAllShoesPairs().Count());
            Assert.AreEqual(6, dataRepository.GetAllTransactions().Count());
        }
    }
}