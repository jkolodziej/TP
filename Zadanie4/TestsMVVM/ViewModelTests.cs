using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TestsMVVM;

namespace ViewModel.Tests
{
    [TestClass()]
    public class ViewModelTests
    {
        private ViewModel viewModel;

        [TestInitialize()]
        public void Initialize()
        {
            viewModel = new ViewModel(new TestingContext());
            viewModel.Async = false;
            viewModel.DisplayMessageBoxes = false;
        }

        [TestMethod()]
        public void AddNewLocationTest()
        {
            viewModel.Name = "TestLocation";
            viewModel.CostRate = new decimal(12.34);
            viewModel.Availability = new decimal(12.34);

            viewModel.AddLocation.Execute(null);
            viewModel.GetAllLocations.Execute(null);
            Assert.AreEqual(7, viewModel.Locations.Count());
        }

        [TestMethod()]
        public void RemoveChosenLocationTest()
        {
            viewModel.Name = "TestLocation";
            viewModel.CostRate = new decimal(12.34);
            viewModel.Availability = new decimal(12.34);

            viewModel.AddLocation.Execute(null);
            viewModel.GetAllLocations.Execute(null);
            Assert.AreEqual(7, viewModel.Locations.Count());
            viewModel.Location = viewModel.Locations.Last();
            viewModel.RemoveLocation.Execute(null);
            Assert.AreEqual(6, viewModel.Locations.Count());
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void AddLocationInvalidTest()
        {
            viewModel.Name = "";
            viewModel.AddLocation.Execute(null);
            viewModel.GetAllLocations.Execute(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UpdateChosenLocationInvalidTest()
        {
            viewModel.Name = "TestLocation";
            viewModel.CostRate = new decimal(12.34);
            viewModel.Availability = new decimal(12.34);

            viewModel.AddLocation.Execute(null);
            viewModel.GetAllLocations.Execute(null);

            viewModel.Location = viewModel.Locations.Last();
            viewModel.Name = "TestName";
            viewModel.CostRate = new decimal(-3);
            viewModel.UpdateLocation.Execute(null);
            viewModel.GetAllLocations.Execute(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void RemoveChosenLocationNullTest()
        {
            viewModel.Location = null;
            viewModel.RemoveLocation.Execute(null);
            viewModel.GetAllLocations.Execute(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void DetailsChosenLocationNullTest()
        {
            viewModel.Location = null;
            viewModel.GetLocation.Execute(null);
            viewModel.GetAllLocations.Execute(null);
        }

        [TestMethod()]
        public void UpdateChosenLocationTest()
        {
            viewModel.Name = "TestLocation";
            viewModel.CostRate = new decimal(12.34);
            viewModel.Availability = new decimal(12.34);

            viewModel.AddLocation.Execute(null);
            viewModel.GetAllLocations.Execute(null);

            viewModel.Location = viewModel.Locations.Last();
            viewModel.Name = "UpdatedTestLocation";
            viewModel.CostRate = new decimal(0);
            viewModel.Availability = new decimal(0);
            viewModel.UpdateLocation.Execute(null);
            
            Assert.AreEqual("UpdatedTestLocation", viewModel.Locations.Last().Name);
            Assert.AreEqual(new decimal(0), viewModel.Locations.Last().CostRate);
            Assert.AreEqual(new decimal(0), viewModel.Locations.Last().Availability);
        }
    }
}