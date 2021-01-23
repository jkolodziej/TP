using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IModel
    {
        void AddLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate);
        MyLocation GetLocation(short id);
        List<MyLocation> GetAllLocations();
        void UpdateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate);
        void DeleteLocation(short id);
    }
}
