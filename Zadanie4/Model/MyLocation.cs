﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyLocation
    {
        public short LocationID { get; set; }
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }

        public MyLocation() { }

        public MyLocation(short locationID, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            LocationID = locationID;
            Name = name;
            CostRate = costRate;
            Availability = availability;
            ModifiedDate = modifiedDate;
        }
    }
}
