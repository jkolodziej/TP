using System.Collections.Generic;
using System.Collections.ObjectModel;
using ShoeStore.Entities;


namespace ShoeStore
{
    public class DataContext
    {
        public List<Client> ClientList = new List<Client>();
        public Dictionary<int, Shoes> ShoesDictionary = new Dictionary<int, Shoes>();
        public ObservableCollection<Transaction> TransactionCollection = new ObservableCollection<Transaction>();
        public List<ShoesPair> ShoesPairList = new List<ShoesPair>();
    }
}
