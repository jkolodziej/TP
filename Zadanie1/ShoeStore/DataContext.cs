using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ShoeStore
{
    public class DataContext
    {
        public List<Client> ClientList = new List<Client>();
        public Dictionary<Guid, Shoes> ShoesDictionary = new Dictionary<Guid, Shoes>();
        public ObservableCollection<Invoice> InvoiceCollection = new ObservableCollection<Invoice>();
        public List<ShoesDetail> ShoesDetailList = new List<ShoesDetail>();
    }
}
