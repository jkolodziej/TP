using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    class Address
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
    }
}
