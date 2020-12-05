using System;
using System.Runtime.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    public abstract class Transaction : ISerializable
    {
        public Client Client { get; set; }
        public ShoesPair ShoesPair { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }

        public Transaction(Client client, ShoesPair shoesPair, int count)
        {
            Client = client;
            ShoesPair = shoesPair;
            Count = count;
            Date = DateTime.Now;
        }

        protected Transaction(SerializationInfo info, StreamingContext context)
        {
            Client = (Client) info.GetValue("Client", typeof(Client));
            ShoesPair = (ShoesPair) info.GetValue("ShoesPair", typeof(ShoesPair));
            Count = info.GetInt32("Count");
            Date = info.GetDateTime("Date");
        }

        public override string ToString()
        {
            return "\nClient: " + Client.ToString() + "\nShoes pair: " + ShoesPair.ToString()
                 + "\nCount: " + Count + "\nDate: " + Date;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Client", Client);
            info.AddValue("ShoesPair", ShoesPair);
            info.AddValue("Count", Count);
            info.AddValue("Date", Date);
        }
    }
}
