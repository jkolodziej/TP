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

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Client i = (Client)obj;
                return this.Name.Equals(i.Name) && this.Surname.Equals(i.Surname) 
                       && this.EmailAddress.Equals(i.EmailAddress) &&
                       this.Address.Equals(i.Address) && this.PhoneNumber.Equals(i.PhoneNumber);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
