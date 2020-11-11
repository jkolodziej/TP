using System;
using System.Collections.Generic;
using System.Linq;
using ShoeStore.Model;

namespace ShoeStore.Logic
{
    public class DataService
    {
        private readonly DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void AddShoes(string shoesModel, int size, string brand, Shoes.SexEnum sex)
        {
            Shoes shoes = new Shoes(shoesModel, size, brand, sex);
            dataRepository.AddShoes(shoes);
        }

        public void AddClient(string name, string surname, string emailAddress, Address address, string phoneNumber)
        {
            Client client = new Client(name, surname, emailAddress, address, phoneNumber);
            dataRepository.AddClient(client);
        }

        // create invoice
        public void BuyShoes(Guid id, Client client, ShoesPair shoesDetail, int count, decimal shippingCost, DateTimeOffset purchaseDate)
        {
            Invoice invoice = new Invoice(id, client, shoesDetail, count, shippingCost, purchaseDate);
            dataRepository.AddInvoice(invoice);
        }

        public void ReturnShoes(ShoesPair shoesDetail)
        {
            //
        }

        //
        public IEnumerable<Shoes> GetAllShoes()
        {
            return dataRepository.getAllShoes();
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return dataRepository.getAllInvoices();
        }

        public IEnumerable<ShoesPair> GetAllShoesDetail(Shoes shoes)
        {
            return dataRepository.getAllShoesPairs().Where(x => x.Shoes == shoes);
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
