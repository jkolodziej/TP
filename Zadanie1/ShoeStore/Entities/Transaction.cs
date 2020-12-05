using System;

namespace ShoeStore.Data
{
    public abstract class Transaction
    {
        public Client Client { get; set; }
        public ShoesPair ShoesPair { get; set; }
        public int Count { get; set; }
        public DateTimeOffset Date { get; set; }

        public Transaction(Client client, ShoesPair shoesPair, int count)
        {
            Client = client;
            ShoesPair = shoesPair;
            Count = count;
            Date = DateTimeOffset.Now;
        }
    }
}
