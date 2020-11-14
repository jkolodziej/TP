using ShoeStore.Entities;
using System;
using System.Collections.Generic;

namespace ShoeStore.Logic
{
    public interface IDataService
    {
        public void AddShoes(string shoesModel, int size, string brand, Shoes.SexEnum sex);

        public void AddClient(string name, string surname, string emailAddress, string address, string phoneNumber);

        public void AddShoesPair(Shoes shoes, decimal nettoPrice, decimal tax, int stockCount, decimal discount);

        public void BuyShoes(Client client, ShoesPair shoesPair, int count, decimal shippingCost);

        public void ReturnShoes(ShoesPair shoesPair, Transaction invoice);

        public IEnumerable<Shoes> GetAllShoes();

        public IEnumerable<Client> GetAllClients();

        public IEnumerable<ShoesPair> GetAllShoesPairs();

        public IEnumerable<ShoesPair> GetAllShoesPairs(Shoes shoes);

        public IEnumerable<Transaction> GetAllTransactions();

        public IEnumerable<Transaction> GetAllTransactionsForClient(Client client);

        public IEnumerable<Transaction> GetAllInvoicesBetween(DateTimeOffset startDate, DateTimeOffset endDate);

        public List<string> GetListOfShoes();

        public Shoes GetShoes(int key);

        public Client GetClient(int index);

        public Transaction GetTransaction(int index);

        public ShoesPair GetShoesPair(int index);
    }
}
