using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMVVM
{
    public class TestingContext : IModel
    {
        List<MyLocation> context = new List<MyLocation>();

        public TestingContext()
        {
            context.Add(new MyLocation(101, "Location1", new decimal(12.34), new decimal(12.34), DateTime.Now));
            context.Add(new MyLocation(102, "Location2", new decimal(12.35), new decimal(12.35), DateTime.Now));
            context.Add(new MyLocation(103, "Location3", new decimal(12.36), new decimal(12.36), DateTime.Now));
            context.Add(new MyLocation(104, "Location4", new decimal(12.37), new decimal(12.37), DateTime.Now));
            context.Add(new MyLocation(105, "Location5", new decimal(12.38), new decimal(12.38), DateTime.Now));
            context.Add(new MyLocation(106, "Location6", new decimal(12.39), new decimal(12.39), DateTime.Now));
        }

        public void AddLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            context.Add(new MyLocation(id, name, costRate, availability, modifiedDate));
        }

        public void DeleteLocation(short id)
        {
            context.RemoveAll(location => location.LocationID == id);
        }

        public List<MyLocation> GetAllLocations()
        {
            return context;
        }

        public MyLocation GetLocation(short id)
        {
            return context.FindAll(location => location.LocationID == id).First();
        }

        public void UpdateLocation(short id, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            context.Find(location => location.LocationID == id).Name = name;
            context.Find(location => location.LocationID == id).CostRate = costRate;
            context.Find(location => location.LocationID == id).Availability = availability;
            context.Find(location => location.LocationID == id).ModifiedDate = modifiedDate;
        }
    }
}
