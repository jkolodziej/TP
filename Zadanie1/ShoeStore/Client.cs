using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    class Client
    {
        private string name { get; set; }
        private string surname { get; set; }
        private string emailAddress { get; set; }
        private Address address { get; set; }
        private string phoneNumber { get; set; }

        public Client()
        {
        }

        public Client(string name, string surname, string emailAddress, Address address, string phoneNumber)
        {
            this.name = name;
            this.surname = surname;
            this.emailAddress = emailAddress;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }
    }
}
