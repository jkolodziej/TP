using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ShoeStore.Model
{
    public class DataContext
    {
        public List<Client> ClientList = new List<Client>();
        public Dictionary<int, Shoes> ShoesDictionary = new Dictionary<int, Shoes>();
        public ObservableCollection<Invoice> InvoiceCollection = new ObservableCollection<Invoice>();
        public List<ShoesPair> ShoesPairList = new List<ShoesPair>();
    }
}
