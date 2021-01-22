using Service;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Model : IModel
    {
        public IDataService dataService { get; set; }

        public Model()
        {
            this.dataService = new DataService();
        }

        public string AddLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            return dataService.CreateLocation(id, name, costRate, availability, modifiedDate);
        }

        public MyLocation GetLocation(short id)
        {
            return dataService.GetLocationById(id);
        }

        public List<MyLocation> GetAllLocations()
        {
            return dataService.GetAllLocations();
        }

        public string UpdateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            return dataService.UpdateLocation(id, name, costRate, availability, modifiedDate);
        }

        public string DeleteLocation(short id)
        {
            return dataService.DeleteLocation(id);
        }

        //private void fillCollection(List<Location> data)
        //{
        //    foreach(Location location in data)
        //    {
        //        locations.Add(new Location(location.LocationID, location.Name, location.CostRate, location.Availability, location.ModifiedDate));
        //    }
        //}



    }
}
