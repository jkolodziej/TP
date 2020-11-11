using System;
using System.Collections.Generic;
using System.Linq;
using ShoeStore.Model;

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

        public void AddShoesPair(Guid id, Shoes shoes, decimal nettoPrice, decimal tax, int stockCount, decimal discount)
        {
            ShoesPair shoesPair = new ShoesPair(id, shoes, nettoPrice, tax, stockCount, discount);
            dataRepository.AddShoesPair(shoesPair);
        }

        // create invoice
        public void BuyShoes(Guid id, Client client, ShoesPair shoesDetail, int count, decimal shippingCost, DateTimeOffset purchaseDate)
        {
            Invoice invoice = new Invoice(id, client, shoesDetail, count, shippingCost, purchaseDate);
            dataRepository.AddInvoice(invoice);
        }

        public void ReturnShoes(ShoesPair shoesPair)
        {
            //
        }

        //
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

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return dataRepository.getAllInvoices();
        }

        public IEnumerable<Invoice> GetAllInvoicesForClient(Client client)
        {
            return GetAllInvoices().Where(invoice => invoice.Client.Equals(client));
        }

        public IEnumerable<Invoice> GetAllInvoicesBetween(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return dataRepository.getAllInvoices().Where(invoice => invoice.PurchaseDate >= startDate && invoice.PurchaseDate <= endDate);
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
