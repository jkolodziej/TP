using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class DataRepository : IDataRepository, IDisposable
    {
        private DatabaseDataContext dbContext;
        private List<DataLocation> dataLocations;

        public DataRepository(DatabaseDataContext dataContext)
        {
            this.dbContext = dataContext;
            dataLocations = dbContext.Location.AsEnumerable().Select(location => new DataLocation(location)).ToList();
        }

        public string AddLocation(DataLocation dataLocation)
        {
            Location location = new Location();
            location.LocationID = dataLocation.LocationID;
            location.Name = dataLocation.Name;
            location.CostRate = dataLocation.CostRate;
            location.Availability = dataLocation.Availability;
            location.ModifiedDate = dataLocation.ModifiedDate;

            dbContext.Location.InsertOnSubmit(location);
            try
            {
                dbContext.SubmitChanges();
            }
            catch (Exception e)
            {
                dbContext.Location.DeleteOnSubmit(location);
                return "Could not add a location";
            }

            return "Location added successfully";
        }

        public List<DataLocation> GetAllLocations()
        {
            return (from location in dataLocations
                    select location).ToList();
        }

        public DataLocation GetLocation(short locationID)
        {
            return (from location in dataLocations
                    where location.LocationID.Equals(locationID)
                    select location).FirstOrDefault();
        }

        public string UpdateLocation(short locationID, DataLocation newLocation)
        {
            Location toUpdate = dbContext.Location.SingleOrDefault(location => location.LocationID == locationID);

            toUpdate.Name = newLocation.Name;
            toUpdate.CostRate = newLocation.CostRate;
            toUpdate.Availability = newLocation.Availability;
            toUpdate.ModifiedDate = newLocation.ModifiedDate;

            try
            {
                dbContext.SubmitChanges();
            }
            catch
            {
                return "Could not submit changes";
            }
            return "Changes submitted successfully";
        }

        public string RemoveLocation(short locationID)
        {
            Location toRemove = dbContext.Location.SingleOrDefault(location => location.LocationID == locationID);

            if (toRemove != null)
            {
                dbContext.Location.DeleteOnSubmit(toRemove);
                try
                {
                    dbContext.SubmitChanges();
                }
                catch (Exception e)
                {
                    dbContext.Location.InsertOnSubmit(toRemove);
                    return $"Location with ID: {locationID} does not exist";
                }
            }
            return "Location removed successfully";
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
