using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ShoeStore
{
    public class DataService
    {
        private readonly DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public Shoes AddShoes(Guid id, string shoesType, int size, string brand, Color color, Shoes.SexEnum sex)
        {
            Shoes shoes = new Shoes(id, shoesType, size, brand, color, sex);
            dataRepository.AddShoes(shoes);
            return shoes;
        }

        public Client AddClient(string name, string surname, string emailAddress, Address address, string phoneNumber)
        {
            Client client = new Client(name, surname, emailAddress, address, phoneNumber);
            dataRepository.AddClient(client);
            return client;
        }

        // create invoice
        public void BuyShoes(Guid id, Client client, ShoesDetail shoesDetail, int count, decimal shippingCost, DateTimeOffset purchaseDate)
        {
            Invoice invoice = new Invoice(id, client, shoesDetail, count, shippingCost, purchaseDate);
            dataRepository.AddInvoice(invoice);
        }

        public void ReturnShoes(ShoesDetail shoesDetail)
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

        public IEnumerable<ShoesDetail> GetAllShoesDetail(Shoes shoes)
        {
            return dataRepository.getAllShoesDetails().Where(x => x.Shoes == shoes);
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
