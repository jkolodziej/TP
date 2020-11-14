using ShoeStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoeStore.Logic
{
    public class DataService : IDataService
    {
        private IDataRepository dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void AddShoes(string shoesModel, int size, string brand, Shoes.SexEnum sex)
        {
            Shoes shoes = new Shoes(shoesModel, size, brand, sex);
            dataRepository.AddShoes(shoes);
        }

        public void AddClient(string name, string surname, string emailAddress, string address, string phoneNumber)
        {
            Client client = new Client(name, surname, emailAddress, address, phoneNumber);
            dataRepository.AddClient(client);
        }

        public void AddShoesPair(Shoes shoes, decimal nettoPrice, decimal tax, int stockCount, decimal discount)
        {
            ShoesPair shoesPair = new ShoesPair(shoes, nettoPrice, tax, stockCount, discount);
            dataRepository.AddShoesPair(shoesPair);
        }

        // create invoice
        public void BuyShoes(Client client, ShoesPair shoesPair, int count, decimal shippingCost)
        {
            if(dataRepository.IsShoesPairAvailable(shoesPair, count))
            {
                Transaction invoice = new Invoice(client, shoesPair, count, shippingCost);
                dataRepository.DecreaseStockCount(shoesPair, invoice);
                dataRepository.AddTransaction(invoice);
            }
            else
            {
                throw new ArgumentException($"No such number of pairs in stock. Current number in stock: {shoesPair.StockCount}");
            }            
        }

        public void ReturnShoes(ShoesPair shoesPair, Transaction invoice)
        {
            Transaction ret = new Return(invoice.Client, invoice.ShoesPair, invoice.Count);
            dataRepository.DeleteTransaction(invoice);
            dataRepository.AddTransaction(ret);          
            dataRepository.IncreaseStockCount(shoesPair, ret);           
        }

        public IEnumerable<Shoes> GetAllShoes()
        {
            return dataRepository.GetAllShoes();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return dataRepository.GetAllClients();
        }

        public IEnumerable<ShoesPair> GetAllShoesPairs()
        {
            return dataRepository.GetAllShoesPairs();
        }

        public IEnumerable<ShoesPair> GetAllShoesPairs(Shoes shoes)
        {
            return dataRepository.GetAllShoesPairs().Where(x => x.Shoes == shoes);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return dataRepository.GetAllTransactions();
        }

        public IEnumerable<Transaction> GetAllTransactionsForClient(Client client)
        {
            return GetAllTransactions().Where(t => t.Client.Equals(client));
        }

        public IEnumerable<Transaction> GetAllInvoicesBetween(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return dataRepository.GetAllTransactions().Where(t => t is Invoice).Where(t => t.Date.CompareTo(startDate) >= 0 && t.Date.CompareTo(endDate) <= 0);
        }

        public List<string> GetListOfShoes()
        {
            List<string> listOfShoes = new List<string>();
            
            foreach(Shoes shoes in dataRepository.GetAllShoes())
            {
                listOfShoes.Add(shoes.ToString());
            }

            return listOfShoes;
        }

        public Shoes GetShoes(int key)
        {
            return dataRepository.GetShoes(key);
        }

        public Client GetClient(int index)
        {
            return dataRepository.GetClient(index);
        }

        public Transaction GetTransaction(int index)
        {
            return dataRepository.GetTransaction(index);
        }

        public ShoesPair GetShoesPair(int index)
        {
            return dataRepository.GetShoesPair(index);
        }
    }
}
