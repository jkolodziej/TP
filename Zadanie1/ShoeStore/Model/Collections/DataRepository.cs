using System;
using System.Collections.Generic;
using System.Linq;
using ShoeStore.Model;

namespace ShoeStore
{
    public class DataRepository //do zrobienia metody update
    {
        private DataContext DataContext = new DataContext();
        private IDataFiller DataFiller;
        private int modelKey;

        public DataRepository(IDataFiller dataFiller)
        {
            this.DataFiller = dataFiller;
            this.DataFiller.Fill(this.DataContext);
            this.modelKey = 0;
        }

        //SHOES

        public void AddShoes(Shoes shoes)
        {
            DataContext.ShoesDictionary.Add(modelKey, shoes);
            modelKey++;
        }

        public Shoes GetShoes(int key)
        {
            if (!DataContext.ShoesDictionary.ContainsKey(key))
            {
                throw new ArgumentException($"Shoes with key: {key} don't exist.");
            }
            return DataContext.ShoesDictionary[key];
        }

        public IEnumerable<Shoes> getAllShoes()
        {
            return DataContext.ShoesDictionary.Values;
        }

        public void UpdateShoes(int key, Shoes shoes) //do wypełnienia
        {
            if (!DataContext.ShoesDictionary.ContainsKey(key))
            {
                throw new ArgumentException($"Shoes with key: {key} don't exist.");
            }
            //do przetestowania
            DataContext.ShoesDictionary[key] = shoes;
        }

        public void DeleteShoes(int key)
        {
            if (!DataContext.ShoesDictionary.ContainsKey(key))
            {
                throw new ArgumentException($"Shoes with key: {key} don't exist.");
            }
            DataContext.ShoesDictionary.Remove(key);
        }

        //CLIENTS

        public void AddClient(Client newClient)
        {
            if (DataContext.ClientList.Any(client => client.EmailAddress.Equals(newClient.EmailAddress)))
            {
                throw new ArgumentException($"Client with e-mail address: {newClient.EmailAddress} already exist in the repository.");
            }
            DataContext.ClientList.Add(newClient);
        }

        public Client GetClient(string email)
        {
            return DataContext.ClientList.FirstOrDefault(client => client.EmailAddress.Equals(email));
        }

        public IEnumerable<Client> getAllClients()
        {
            return DataContext.ClientList;
        }

        public void UpdateClient(Client client) //do wypełnienia
        {
            if (!DataContext.ClientList.Any(c => c.EmailAddress.Equals(client.EmailAddress)))
            {
                throw new ArgumentException($"Client with e-mail address {client.EmailAddress} doesn't exist in the repository");
            }
            //do przetestowania
            int index = DataContext.ClientList.IndexOf(DataContext.ClientList.FirstOrDefault(c => c.EmailAddress.Equals(client.EmailAddress)));
            DataContext.ClientList.Insert(index, client);
        }

        public void DeleteClient(Client client)
        {
            if (!DataContext.ClientList.Any(c => c.EmailAddress.Equals(client.EmailAddress)))
            {
                throw new ArgumentException($"Client with e-mail address {client.EmailAddress} doesn't exist in the repository");
            }
            DataContext.ClientList.Remove(client);
        }

        //INVOICES


        public void AddInvoice(Invoice newInvoice)
        {
            if (DataContext.InvoiceCollection.Any(invoice => invoice.Id.Equals(newInvoice.Id)))
            {
                throw new ArgumentException($"Invoice with ID: {newInvoice.Id} already exist in the repository.");
            }
            DataContext.InvoiceCollection.Add(newInvoice);
        }

        public Invoice GetInvoice(Guid id)
        {
            return DataContext.InvoiceCollection.FirstOrDefault(invoice => invoice.Id.Equals(invoice.Id));
        }

        public IEnumerable<Invoice> getAllInvoices()
        {
            return DataContext.InvoiceCollection;
        }

        public void UpdateInvoice(Invoice invoice) //do wypełnienia
        {
            if (!DataContext.InvoiceCollection.Any(i => i.Id.Equals(invoice.Id)))
            {
                throw new ArgumentException($"Invoice with ID: {invoice.Id} doesn't exist in the repository");
            }
            //do przetestowania
            int index = DataContext.InvoiceCollection.IndexOf(DataContext.InvoiceCollection.FirstOrDefault(i => i.Id.Equals(i.Id)));
            DataContext.InvoiceCollection.Insert(index, invoice);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            if (!DataContext.InvoiceCollection.Any(i => i.Id.Equals(invoice.Id)))
            {
                throw new ArgumentException($"Invoice with ID: {invoice.Id} doesn't exist.");
            }
            DataContext.InvoiceCollection.Remove(invoice);
        }

        //SHOES_DETAILS

        public void AddShoesPair(ShoesPair shoesPair)
        {
            if (DataContext.ShoesPairList.Any(sd => sd.Id.Equals(shoesPair.Id)))
            {
                throw new ArgumentException($"ShoesPair with ID: {shoesPair.Id} already exist in the repository.");
            }
            DataContext.ShoesPairList.Add(shoesPair);
        }

        public ShoesPair GetShoesPair(int index)
        {
            //return DataContext.ShoesPairList.FirstOrDefault(sd => sd.Id.Equals(id));
            if(DataContext.ShoesPairList[index] == null)
            {
                throw new ArgumentException($"There's no ShoesPair with index: {index}.");
            }
            return DataContext.ShoesPairList[index];
        }

        public IEnumerable<ShoesPair> getAllShoesPairs()
        {
            return DataContext.ShoesPairList;
        }

        public void UpdateShoesPair(ShoesPair shoesP) //do wypełnienia
        {
            if (!DataContext.ShoesPairList.Any(sp => sp.Id.Equals(sp.Id)))
            {
                throw new ArgumentException($"Pair of shoes with ID: {shoesP.Id} doesn't exist in the repository");
            }
            //do przetestowania
            int index = DataContext.ShoesPairList.IndexOf(DataContext.ShoesPairList.FirstOrDefault(sp => sp.Id.Equals(sp.Id)));
            DataContext.ShoesPairList.Insert(index, shoesP);
        }

        public void DeleteShoesPair(ShoesPair shoesDetail)
        {
            if (!DataContext.ShoesPairList.Any(sd => sd.Id.Equals(shoesDetail.Id)))
            {
                throw new ArgumentException($"ShoesDetail with ID: {shoesDetail.Id} doesn't exist.");
            }
            DataContext.ShoesPairList.Remove(shoesDetail);
        }
    }
}
