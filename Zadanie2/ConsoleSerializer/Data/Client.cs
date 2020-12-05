using System;
using System.Runtime.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    public class Client : ISerializable 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Client(string name, string surname, string emailAddress, string address, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            EmailAddress = emailAddress;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        protected Client(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Surname = info.GetString("Surname");
            EmailAddress = info.GetString("EmailAddress");
            Address = info.GetString("Address");
            PhoneNumber = info.GetString("PhoneNumber");
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
                return this.Name.Equals(i.Name) &&
                       this.Surname.Equals(i.Surname) && this.EmailAddress.Equals(i.EmailAddress) &&
                       this.Address.Equals(i.Address) && this.PhoneNumber.Equals(i.PhoneNumber);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "\nName: " + Name + "\nSurname: " + Surname
                 + "\nEmail Address: " + EmailAddress + "\nAddress: " + Address
                 + "\nPhone Number: " + PhoneNumber; 
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Surname", Surname);
            info.AddValue("EmailAddress", EmailAddress);
            info.AddValue("Address", Address);
            info.AddValue("PhoneNumber", PhoneNumber);
        }
    }
}
