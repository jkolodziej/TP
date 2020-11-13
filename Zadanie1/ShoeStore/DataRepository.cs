using System;
using System.Collections.Generic;
using System.Linq;
using ShoeStore.Entities;
using ShoeStore.Fillers;

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

        public Client GetClient(int index)
        {
            if (DataContext.ClientList[index] == null)
            {
                throw new ArgumentException($"Client with index: {index} doesn't exist in the repository");
            }
            return DataContext.ClientList[index];
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
            if (DataContext.InvoiceCollection.Any(invoice => invoice.Equals(newInvoice)))
            {
                throw new ArgumentException($"Invoice: {newInvoice} already exist in the repository.");
            }
            DataContext.InvoiceCollection.Add(newInvoice);
        }

        public Invoice GetInvoice(int index)
        {
            if (DataContext.InvoiceCollection[index] == null)
            {
                throw new ArgumentException($"There's no ShoesPair with index: {index}.");
            }
            return DataContext.InvoiceCollection[index];
        }

        public IEnumerable<Invoice> getAllInvoices()
        {
            return DataContext.InvoiceCollection;
        }

        public void UpdateInvoice(int index, Invoice invoice) //do wypełnienia
        {
            if (DataContext.InvoiceCollection[index] == null)
            {
                throw new ArgumentException($"Invoice with index: {index} doesn't exist in the repository");
            }
            //do przetestowania
            DataContext.InvoiceCollection.Insert(index, invoice);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            if (!DataContext.InvoiceCollection.Any(i => i.Equals(invoice)))
            {
                throw new ArgumentException($"Invoice: {invoice} doesn't exist.");
            }
            DataContext.InvoiceCollection.Remove(invoice);
        }

        // SHOES_PAIR

        public void AddShoesPair(ShoesPair shoesPair)
        {
            if (DataContext.ShoesPairList.Any(sp => sp.Equals(shoesPair)))
            {
                throw new ArgumentException($"ShoesPair: {shoesPair} already exist in the repository.");
            }
            DataContext.ShoesPairList.Add(shoesPair);
        }

        public ShoesPair GetShoesPair(int index)
        {
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

        public void UpdateShoesPair(int index, ShoesPair shoesPair) //do wypełnienia
        {
            if (DataContext.ShoesPairList[index] == null)
            {
                throw new ArgumentException($"Pair of shoes with: {index} doesn't exist in the repository");
            }
            //do przetestowania
            DataContext.ShoesPairList.Insert(index, shoesPair);
        }

        public void DeleteShoesPair(ShoesPair shoesPair)
        {
            if (!DataContext.ShoesPairList.Any(sp => sp.Equals(shoesPair)))
            {
                throw new ArgumentException($"Pair of shoes: {shoesPair} doesn't exist.");
            }
            DataContext.ShoesPairList.Remove(shoesPair);
        }
    }
}
