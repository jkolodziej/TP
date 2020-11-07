using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    class Address
    {
        private string city { get; set; }
        private string street { get; set; }
        private string houseNumber { get; set; }

        public Address(string city, string street, string houseNumber)
        {
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
        }
    }
}
