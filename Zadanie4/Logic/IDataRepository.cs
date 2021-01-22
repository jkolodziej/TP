using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    interface IDataRepository
    {
        string AddLocation(Location location);
        Location GetLocation(short locationID);
        List<Location> GetAllLocations();       
        string UpdateLocation(short id, Location location);
        string RemoveLocation(short locationID);
    }
}
