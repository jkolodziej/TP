using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public Address(string city, string street, string houseNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Address i = (Address)obj;
                return this.City.Equals(i.City) && this.Street.Equals(i.Street) &&
                       this.HouseNumber.Equals(i.HouseNumber);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
