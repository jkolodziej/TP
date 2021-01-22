using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class DataService : IDataService
    {
        private IDataRepository dataRepository;

        public DataService()
        {
            dataRepository = new DataRepository(new DatabaseDataContext());
        }

        public string CreateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)        {
            Location location = new Location();
            location.LocationID = id;
            location.Name = name;
            location.CostRate = costRate;
            location.Availability = availability;
            location.ModifiedDate = modifiedDate;
            return dataRepository.AddLocation(new DataLocation(location));
        }

        public List<MyLocation> GetAllLocations()
        {
            return dataRepository.GetAllLocations().Select(l => new MyLocation(l.LocationID, l.Name, l.CostRate, l.Availability, l.ModifiedDate)).ToList();
        }

        public MyLocation GetLocationById(short id)
        {
            DataLocation location = dataRepository.GetLocation(id);
            return new MyLocation(location.LocationID, location.Name, location.CostRate, location.Availability, location.ModifiedDate);
        }

        public string UpdateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            Location location = new Location();
            location.LocationID = id;
            location.Name = name;
            location.CostRate = costRate;
            location.Availability = availability;
            location.ModifiedDate = modifiedDate;
            DataLocation dataLocation = new DataLocation(location);
            return dataRepository.UpdateLocation(id, dataLocation);
        }

        public string DeleteLocation(short id)
        {
            return dataRepository.RemoveLocation(id);
        }
    }
}
