﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDataService
    {
        string CreateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate);
        MyLocation GetLocationById(short id);
        List<MyLocation> GetAllLocations();
        string UpdateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate);
        string DeleteLocation(short id);
    }
}
