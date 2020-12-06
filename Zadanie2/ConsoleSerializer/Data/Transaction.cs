using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    [XmlRoot("Transaction")]
    public abstract class Transaction : ISerializable
    {
        public Client Client { get; set; }
        [XmlArrayAttribute("ShoesPairs")]
        public List<ShoesPair> ShoesPairs { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }

        public Transaction(){}

        public Transaction(Client client, List<ShoesPair> shoesPair, int count)
        {
            Client = client;
            ShoesPairs = shoesPair;
            Count = count;
            Date = DateTime.Now;
        }

        protected Transaction(SerializationInfo info, StreamingContext context)
        {
            Client = (Client) info.GetValue("Client", typeof(Client));
            ShoesPairs = (List<ShoesPair>) info.GetValue("ShoesPairs", typeof(List<ShoesPair>));
            Count = info.GetInt32("Count");
            Date = info.GetDateTime("Date");
        }

        public string shoesPairsToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (ShoesPair shoesPair in ShoesPairs)
            {
                str.Append(shoesPair.ToString());
            }
            return str.ToString();
        }
        public override string ToString()
        {
            return "\nClient: " + Client.ToString() + "\nShoes pair: " + shoesPairsToString()
                 + "\nCount: " + Count + "\nDate: " + Date;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Client", Client);
            info.AddValue("ShoesPair", ShoesPairs);
            info.AddValue("Count", Count);
            info.AddValue("Date", Date);
        }
    }
}
