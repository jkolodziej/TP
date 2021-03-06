﻿
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoeStore.Data
{
    public class DataRepository : IDataRepository
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

        public void AddShoes(Shoes newShoes)
        {
            if (DataContext.ShoesDictionary.Any(shoes => (shoes.Value.Equals(newShoes))))
            {
                throw new ArgumentException($"Shoes model: {newShoes.ShoesModel} with size {newShoes.Size} already exist in the repository.");
            }
            DataContext.ShoesDictionary.Add(modelKey, newShoes);
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

        public IEnumerable<Shoes> GetAllShoes()
        {
            return DataContext.ShoesDictionary.Values;
        }

        public void UpdateShoes(int key, Shoes shoes) 
        {
            if (!DataContext.ShoesDictionary.ContainsKey(key))
            {
                throw new ArgumentException($"Shoes with key: {key} don't exist.");
            }
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
            if (!(index >=0 && index < DataContext.ClientList.Count))
            {
                throw new ArgumentException($"Client with index: {index} doesn't exist in the repository");
            }
            return DataContext.ClientList[index];
        }

        public IEnumerable<Client> GetAllClients()
        {
            return DataContext.ClientList;
        }

        public void UpdateClient(Client client) 
        {
            if (!DataContext.ClientList.Any(c => c.EmailAddress.Equals(client.EmailAddress)))
            {
                throw new ArgumentException($"Client with e-mail address {client.EmailAddress} doesn't exist in the repository");
            }
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

        public void AddTransaction(Transaction newTransaction)
        {
            if (DataContext.TransactionCollection.Any(invoice => invoice.Equals(newTransaction)))
            {
                throw new ArgumentException($"Transaction: {newTransaction} already exist in the repository.");
            }
            DataContext.TransactionCollection.Add(newTransaction);
        }

        public Transaction GetTransaction(int index)
        {
            if (!(index >= 0 && index < DataContext.TransactionCollection.Count))
            {
                throw new ArgumentException($"There's no transaction with index: {index}.");
            }
            return DataContext.TransactionCollection[index];
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return DataContext.TransactionCollection;
        }

        public void UpdateTransaction(int index, Transaction transaction)
        {
            if (!(index >= 0 && index < DataContext.TransactionCollection.Count))
            {
                throw new ArgumentException($"Transaction with index: {index} doesn't exist in the repository");
            }
            DataContext.TransactionCollection.Insert(index, transaction);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            if (!DataContext.TransactionCollection.Any(i => i.Equals(transaction)))
            {
                throw new ArgumentException($"Transaction: {transaction} doesn't exist.");
            }
            DataContext.TransactionCollection.Remove(transaction);
        }

        // SHOES_PAIR

        public void IncreaseStockCount(ShoesPair shoesPair, Transaction invoice)
        {
            if (!DataContext.ShoesPairList.Any(sp => sp.Equals(shoesPair)))
            {
                throw new ArgumentException($"ShoesPair: {shoesPair} doensn't exist in the repository.");
            }
            int index = DataContext.ShoesPairList.IndexOf(shoesPair);
            DataContext.ShoesPairList[index].StockCount += invoice.Count;
        }

        public void DecreaseStockCount(ShoesPair shoesPair, Transaction ret)
        {
            if (!DataContext.ShoesPairList.Any(sp => sp.Equals(shoesPair)))
            {
                throw new ArgumentException($"ShoesPair: {shoesPair} doensn't exist in the repository.");
            }
            int index = DataContext.ShoesPairList.IndexOf(shoesPair);
            DataContext.ShoesPairList[index].StockCount -= ret.Count;
        }

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
            if (!(index >= 0 && index < DataContext.ShoesPairList.Count))
            {
                throw new ArgumentException($"There's no ShoesPair with index: {index}.");
            }
            return DataContext.ShoesPairList[index];
        }

        public IEnumerable<ShoesPair> GetAllShoesPairs()
        {
            return DataContext.ShoesPairList;
        }

        public void UpdateShoesPair(int index, ShoesPair shoesPair)
        {
            if (!(index >= 0 && index < DataContext.ShoesPairList.Count))
            {
                throw new ArgumentException($"Pair of shoes with: {index} doesn't exist in the repository");
            }
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

        public Boolean IsShoesPairAvailable(ShoesPair shoesPair, int count)
        {
            if (shoesPair.StockCount >= count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
