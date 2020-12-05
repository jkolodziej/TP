
using System;
using System.Collections.Generic;

namespace ShoeStore.Data
{
    public interface IDataRepository
    {
        //SHOES 

        public void AddShoes(Shoes shoes);
        public Shoes GetShoes(int key);
        public IEnumerable<Shoes> GetAllShoes();
        public void UpdateShoes(int key, Shoes shoes);
        public void DeleteShoes(int key);

        //CLIENTS

        public void AddClient(Client newClient);
        public Client GetClient(int index);
        public IEnumerable<Client> GetAllClients();
        public void UpdateClient(Client client);
        public void DeleteClient(Client client);

        //INVOICES

        public void AddTransaction(Transaction newTransaction);
        public Transaction GetTransaction(int index);
        public IEnumerable<Transaction> GetAllTransactions();
        public void UpdateTransaction(int index, Transaction transaction);
        public void DeleteTransaction(Transaction transaction);

        // SHOES_PAIRS

        public void IncreaseStockCount(ShoesPair shoesPair, Transaction invoice);
        public void DecreaseStockCount(ShoesPair shoesPair, Transaction ret);
        public void AddShoesPair(ShoesPair shoesPair);
        public ShoesPair GetShoesPair(int index);
        public IEnumerable<ShoesPair> GetAllShoesPairs();
        public void UpdateShoesPair(int index, ShoesPair shoesPair);
        public void DeleteShoesPair(ShoesPair shoesPair);
        public Boolean IsShoesPairAvailable(ShoesPair shoesPair, int count);
    }
}

