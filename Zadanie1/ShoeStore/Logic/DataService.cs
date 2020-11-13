using System;
using System.Collections.Generic;
using System.Linq;
using ShoeStore.Entities;

namespace ShoeStore.Logic
{
    public class DataService
    {
        private DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
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
        public void BuyShoes(Client client, ShoesPair shoesPair, int count, decimal shippingCost, DateTimeOffset purchaseDate)
        {
            Transaction invoice = new Invoice(client, shoesPair, count, shippingCost, purchaseDate);
            dataRepository.IncreaseStockCount(shoesPair, invoice);           
            dataRepository.AddTransaction(invoice);
        }

        public void ReturnShoes(ShoesPair shoesPair, Transaction invoice)
        {
            Transaction ret = new Return(invoice.Client, invoice.ShoesPair, invoice.Count);
            dataRepository.DeleteTransaction(invoice);
            dataRepository.AddTransaction(ret);          
            dataRepository.AddShoesPair(shoesPair);
            dataRepository.DecreaseStockCount(shoesPair, ret);           
        }

        public IEnumerable<Shoes> GetAllShoes()
        {
            return dataRepository.getAllShoes();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return dataRepository.getAllClients();
        }

        public IEnumerable<ShoesPair> GetAllShoesPairs()
        {
            return dataRepository.getAllShoesPairs();
        }

        public IEnumerable<ShoesPair> GetAllShoesPairs(Shoes shoes)
        {
            return dataRepository.getAllShoesPairs().Where(x => x.Shoes == shoes);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return dataRepository.getAllTransactions();
        }

        public IEnumerable<Transaction> GetAllTransactionsForClient(Client client)
        {
            return GetAllTransactions().Where(t => t.Client.Equals(client));
        }

        public IEnumerable<Transaction> GetAllInvoicesBetween(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return dataRepository.getAllTransactions().Where(t => t is Invoice).Where(t => t.Date.CompareTo(startDate) >= 0 && t.Date.CompareTo(endDate) <= 0);
        }

        public List<string> GetListOfShoes()
        {
            List<string> listOfShoes = new List<string>();
            
            foreach(Shoes shoes in dataRepository.getAllShoes())
            {
                listOfShoes.Add(shoes.ToString());
            }

            return listOfShoes;
        }
    }
}
