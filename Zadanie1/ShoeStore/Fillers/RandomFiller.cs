using ShoeStore.Data;
using System;

namespace ShoeStore.Data
{
    public class RandomFiller : IDataFiller
    {
        private int ClientsNo;
        private int ShoesNo;
        private Random Rnd = new Random();

        private string[] Names = {"Michał", "Szymon", "Daniel", "Karolina", "Julia", "Dorota", "Patryk", "Dawid", "Kacper", "Monika", "Artur",
                                    "Wojciech", "Ignacy", "Alicja", "Kamil", "Lidia"};
        private string[] Surnames = { "Kowalczyk", "Kołodziej", "Nowak", "Wróbel", "Włodarczyk", "Walczak", "Świercz", "Bieniek" };
        private string[] Brands = { "Nike", "Adidas", "Reebok", "Kazar", "Lasocki", "Dr. Martens", "Steel", "Fila", "Converse" };
        private string[] Cities = { "Warszawa", "Łódź", "Pabianice", "Sieradz", "Zduńska Wola" };
        private string[] Streets = { "Łaska", "Warszawska", "Dobrowolska", "Zamkowa", "Kilińskiego" };

        public RandomFiller(int clientsNo, int shoesNo)
        {
            ClientsNo = clientsNo;
            ShoesNo = shoesNo;
        }

        public string GenHouseNumber()
        {
            int chooser = Rnd.Next(2);
            switch (chooser)
            {
                case 0:
                    {
                        return Rnd.Next(300) + 1 + "/" + Rnd.Next(300) + 1;
                    }
                case 1:
                    {
                        return (Rnd.Next(300)).ToString();
                    }
                case 2:
                    {
                         return Rnd.Next(300) + "A";
                    }
            }            
            return "1";
        }

        public string GenAddress()
        {
            return Cities[Rnd.Next(Cities.Length)] + " ul." + Streets[Rnd.Next(Streets.Length)] + " nr" + GenHouseNumber();
        }

        public string GenEmailSign()
        {
            int chooser = Rnd.Next(3);
            switch (chooser)
            {
                case 0:
                    {
                        return ".";
                    }
                case 1:
                    {
                        return "_";
                    }
                case 2:
                    {
                        return "-";
                    }
                case 3:
                    {
                        return "*";
                    }
            }
            return "?";
        }

        public string GenPhoneNumber()
        {
            string number = string.Empty;
            for (int i = 0; i < 9; i++)
                number = String.Concat(number, Rnd.Next(9).ToString());
            return number;
        }

        public Client CreateClient()
        {
            string name = Names[Rnd.Next(Names.Length)];
            string surname = Surnames[Rnd.Next(Surnames.Length)];
            string emailAddress = name + GenEmailSign() + surname + Rnd.Next(2020) + "@gmail.com";
            Client client = new Client(name, surname, emailAddress, GenAddress(), GenPhoneNumber());
            return client;
        }

        public Shoes.SexEnum GenRndSex()
        {
            int chooser = Rnd.Next(2);
            switch (chooser)
            {
                case 0:
                    {
                        return Shoes.SexEnum.Female;
                    }
                case 1:
                    {
                        return Shoes.SexEnum.Male;
                    }
                case 2:
                    {
                        return Shoes.SexEnum.Unisex;
                    }
            }
            return Shoes.SexEnum.Female;
        }

        public Shoes CreateShoes()
        {
            string brand = Brands[Rnd.Next(Brands.Length)];
            string shoesModel = (brand[0] + Rnd.Next(1000)).ToString();
            Shoes shoes = new Shoes(shoesModel, Rnd.Next(18, 45), brand, GenRndSex());
            return shoes;
        }

        public ShoesPair CreateShoesPair(Shoes shoes)
        {
            ShoesPair shoesPair = new ShoesPair(shoes, Rnd.Next(50, 500), new decimal(0.22), 
                Rnd.Next(10, 1000), new decimal(Rnd.NextDouble() * (0.75 - 0.0) + 0.0));
            return shoesPair;
        }

        public Transaction CreateInvoice(Client client, ShoesPair shoesPair)
        {
            Transaction invoice = new Invoice(client, shoesPair, 1, new decimal(15.90));
            return invoice;
        }

        public void Fill(DataContext dataContext)
        {
            for (int i = 0; i < ClientsNo; i++)
            {
                dataContext.ClientList.Add(CreateClient());
            }
            for (int i = 0; i < ShoesNo; i++)
            {
                dataContext.ShoesDictionary.Add(i + 200, CreateShoes());
                dataContext.ShoesPairList.Add(CreateShoesPair(dataContext.ShoesDictionary[i + 200]));
                dataContext.TransactionCollection.Add(CreateInvoice(dataContext.ClientList[Rnd.Next(ClientsNo - 1)], dataContext.ShoesPairList[i]));
            }
        }
    }
}
