using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TestsMVVM;

namespace Model.Tests
{
    [TestClass()]
    public class ModelTests
    {
        private ViewModel.ViewModel viewModel;

        [TestInitialize()]
        public void Initialize()
        {
            viewModel = new ViewModel.ViewModel(new TestingContext());
        }

        [TestMethod()]
        public void AddLocationTest()
        {
            viewModel.Model.AddLocation(110, "TestLocation", new decimal(12.34), new decimal(56.78), DateTime.Now);
            Assert.AreEqual(viewModel.Model.GetAllLocations().Last().Name, "TestLocation");
            Assert.AreEqual(7, viewModel.Model.GetAllLocations().Count);
        }

        [TestMethod()]
        public void GetLocationTest()
        {
            MyLocation location = viewModel.Model.GetLocation(102);
            Assert.AreEqual(location.Name, "Location2");
            Assert.AreEqual(location.CostRate, new decimal(12.35));
            Assert.AreEqual(location.Availability, new decimal(12.35));
        }

        [TestMethod()]
        public void GetAllLocationsTest()
        {
            Assert.AreEqual(6, viewModel.Model.GetAllLocations().Count());
        }

        [TestMethod()]
        public void UpdateLocationTest()
        {
            viewModel.Model.UpdateLocation(101, "LocationUpdated", new decimal(12.34), new decimal(12.34), DateTime.Now);
            Assert.AreEqual("LocationUpdated", viewModel.Model.GetAllLocations().First().Name);
        }

        [TestMethod()]
        public void DeleteLocationTest()
        {
            viewModel.Model.DeleteLocation(106);
            Assert.AreEqual(viewModel.Model.GetAllLocations().Last().Name, "Location5");
            Assert.AreEqual(5, viewModel.Model.GetAllLocations().Count);
        }
    }
}