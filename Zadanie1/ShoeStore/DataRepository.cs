using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class DataRepository //do zrobienia metody update
    {
        private DataContext DataContext = new DataContext();
        private IDataFiller DataFiller;

        public DataRepository(IDataFiller dataFiller)
        {
            this.DataFiller = dataFiller;
            this.DataFiller.Fill(this.DataContext);
        }

        //SHOES

        public void AddShoes(Shoes shoes)
        {
            if (DataContext.ShoesDictionary.ContainsKey(shoes.Id)){
                throw new ArgumentException($"Shoes with ID: {shoes.Id} already exist in the repository.");
            }
            DataContext.ShoesDictionary.Add(shoes.Id, shoes);
        }

        public Shoes GetShoes(Guid id)
        {
            if (!DataContext.ShoesDictionary.ContainsKey(id))
            {
                throw new ArgumentException($"Shoes with ID: {id} doesn't exist.");
            }
            return DataContext.ShoesDictionary[id];
        }

        public IEnumerable<Shoes> getAllShoes()
        {
            return DataContext.ShoesDictionary.Values;
        }

        public void UpdateShoes() //do wypełnienia
        {

        }

        public void DeleteShoes(Shoes shoes)
        {
            if (!DataContext.ShoesDictionary.ContainsKey(shoes.Id))
            {
                throw new ArgumentException($"Shoes with ID: {shoes.Id} don't exist.");
            }
            DataContext.ShoesDictionary.Remove(shoes.Id);
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

        public void UpdateClient() //do wypełnienia
        {

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

        public void UpdateInvoice() //do wypełnienia
        {

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

        public void AddShoesDetail(ShoesDetail shoesDet)
        {
            if (DataContext.ShoesDetailList.Any(sd => sd.Id.Equals(shoesDet.Id)))
            {
                throw new ArgumentException($"ShoesDetail with ID: {shoesDet.Id} already exist in the repository.");
            }
            DataContext.ShoesDetailList.Add(shoesDet);
        }

        public ShoesDetail GetShoesDetail(Guid id)
        {
            return DataContext.ShoesDetailList.FirstOrDefault(sd => sd.Id.Equals(id));
        }

        /*
        public IEnumerable<Shoes> getAllShoes()
        {
            return DataContext.ShoesDictionary.Values;
        }

        public void UpdateShoes(Guid id) //do wypełnienia
        {

        }

        public void DeleteShoes(Shoes shoes)
        {
            if (!DataContext.ShoesDictionary.ContainsKey(shoes.Id))
            {
                throw new ArgumentException($"Book with ID: {shoes.Id} doesn't exist.");
            }
            DataContext.ShoesDictionary.Remove(shoes.Id);
        }
        */
    }
}
