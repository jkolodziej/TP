using Data;
using System;
using System.Collections.Generic;


namespace Service
{
    public class DataService : IDataService
    {
        private IDataRepository dataRepository; 

        public string CreateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            Location location = new Location();
            location.LocationID = id;
            location.Name = name;
            location.CostRate = costRate;
            location.Availability = availability;
            location.ModifiedDate = modifiedDate;
            return dataRepository.AddLocation(location);
        }

        public Location GetLocationById(short id)
        {
            return dataRepository.GetLocation(id);
        }

        public List<Location> GetAllLocations()
        {
            return dataRepository.GetAllLocations();
        }

        public string UpdateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            Location location = new Location();
            location.LocationID = id;
            location.Name = name;
            location.CostRate = costRate;
            location.Availability = availability;
            location.ModifiedDate = modifiedDate;
            return dataRepository.UpdateLocation(id, location);
        }

        public string DeleteLocation(short id)
        {
            return dataRepository.RemoveLocation(id);
        }
    }
}
