using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Model
{
    public class Model : IModel
    {
        public IDataService dataService { get; set; }

        public ObservableCollection<MyLocation> locations { get; set; }

        public Model()
        {
            this.dataService = new DataService();
            this.locations = FillCollection();
        }

        public Model(IDataService dataService)
        {
            this.dataService = dataService;
            this.locations = FillCollection();
        }

        public void InitLocations()
        {
            locations.Clear();
            locations = FillCollection();
        }

        public string AddLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            return dataService.CreateLocation(id, name, costRate, availability, modifiedDate);
        }

        public MyLocation GetLocation(short id)
        {
            Service.MyLocation location = dataService.GetLocationById(id);
            return new MyLocation(location.LocationID, location.Name, location.CostRate, location.Availability, location.ModifiedDate);
        }

        public List<MyLocation> GetAllLocations()
        {
            return dataService.GetAllLocations().Select(l => new MyLocation(l.LocationID, l.Name, l.CostRate, l.Availability, l.ModifiedDate)).ToList();
        }

        public string UpdateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            return dataService.UpdateLocation(id, name, costRate, availability, modifiedDate);
        }

        public string DeleteLocation(short id)
        {
            return dataService.DeleteLocation(id);
        }

        private ObservableCollection<MyLocation> FillCollection()
        {
            IEnumerable<Service.MyLocation> data = dataService.GetAllLocations();
            ObservableCollection<MyLocation> collection = new ObservableCollection<MyLocation>();
            foreach (Service.MyLocation location in data)
            {
                collection.Add(new MyLocation(location.LocationID, location.Name, location.CostRate, location.Availability, location.ModifiedDate));
            }
            return collection;
        }
        
    }
}
