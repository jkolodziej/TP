using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataLocation : Location
    {
        public DataLocation(Location location)
        {
            foreach(var property in location.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(location));
                }
            }
        }
    }
}
