using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDataRepository
    {
        string AddLocation(DataLocation location);
        DataLocation GetLocation(short locationID);
        List<DataLocation> GetAllLocations();       
        string UpdateLocation(short id, DataLocation location);
        string RemoveLocation(short locationID);
    }
}
