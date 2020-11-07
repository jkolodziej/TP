using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    public class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }

        public Client()
        {
        }

        public Client(string name, string surname, string emailAddress, Address address, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            EmailAddress = emailAddress;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
