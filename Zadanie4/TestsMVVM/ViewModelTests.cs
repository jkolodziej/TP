using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            viewModel.Location = viewModel.Locations.Last();
            viewModel.RemoveLocation.Execute(null);
            Assert.AreEqual(6, viewModel.Locations.Count());
        }
    }
}