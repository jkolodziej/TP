using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    public class DataContext : ISerializable
    {
        public List<Client> ClientList = new List<Client>();
        public Dictionary<int, Shoes> ShoesDictionary = new Dictionary<int, Shoes>();
        public ObservableCollection<Transaction> TransactionCollection = new ObservableCollection<Transaction>();
        public List<ShoesPair> ShoesPairList = new List<ShoesPair>();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           //
        }
    }
}
