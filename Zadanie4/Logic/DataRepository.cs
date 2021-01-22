using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DataRepository : IDataRepository, IDisposable
    {
        private DatabaseDataContext dbContext;

        DataRepository()
        {
            this.dbContext = new DatabaseDataContext();
        }

        public string AddLocation(Location location)
        {
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

        public List<Location> GetAllLocations()
        {
            return (from location in dbContext.Location
                    select location).ToList();

        }

        public Location GetLocation(short locationID)
        {
            return (from location in dbContext.Location
                    where location.LocationID.Equals(locationID)
                    select location).FirstOrDefault();
        }

        public string RemoveLocation(short locationID)
        {
            Location toRemove = (from location in dbContext.Location
                                 where location.LocationID.Equals(locationID)
                                 select location).FirstOrDefault();

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

        public string UpdateLocation(short locationID, Location newLocation)
        {
            Location toUpdate = (from location in dbContext.Location
                                 where location.LocationID.Equals(locationID)
                                 select location).FirstOrDefault();
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

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
