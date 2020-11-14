using ShoeStore.Entities;

namespace ShoeStore.Fillers
{
    public class ConstantFiller : IDataFiller
    {
        public void Fill(DataContext dataContext)
        {
            dataContext.ShoesDictionary.Add(111, new Shoes("AD89", 39, "Adidas", Shoes.SexEnum.Female));
            dataContext.ShoesDictionary.Add(112, new Shoes("AD79", 38, "Adidas", Shoes.SexEnum.Female));
            dataContext.ShoesDictionary.Add(113, new Shoes("NI30", 45, "Nike", Shoes.SexEnum.Male));
            dataContext.ShoesDictionary.Add(114, new Shoes("FI31", 42, "Fila", Shoes.SexEnum.Male));
            dataContext.ShoesDictionary.Add(115, new Shoes("CO45", 40, "Converse", Shoes.SexEnum.Female));

            dataContext.ClientList.Add(new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780"));
            dataContext.ClientList.Add(new Client("Katarzyna", "Kowalska", "katarzyna.kowalska@gmail.com", "Pabianice Zamkowa 23b", "+48123456781"));
            dataContext.ClientList.Add(new Client("Zofia", "Nowak", "zofia.nowak@gmail.com", "Pabianice Zamkowa 23c", "+48123456782"));
            dataContext.ClientList.Add(new Client("Anna", "Poniatowska", "anna.poniatowska@gmail.com", "Pabianice Zamkowa 23d", "+48123456783"));
            dataContext.ClientList.Add(new Client("Piotr", "Nowakowski", "piotr.nowakowski@gmail.com", "Pabianice Zamkowa 23e", "+48123456784"));
            
            dataContext.ShoesPairList.Add(new ShoesPair(dataContext.ShoesDictionary[111], new decimal(300.0),
                            new decimal(0.22), 20, new decimal(0.1)));
            dataContext.ShoesPairList.Add(new ShoesPair(dataContext.ShoesDictionary[112], new decimal(400.0),
                            new decimal(0.22), 20, new decimal(0.1)));
            dataContext.ShoesPairList.Add(new ShoesPair(dataContext.ShoesDictionary[113], new decimal(300.0),
                            new decimal(0.22), 20, new decimal(0.1)));
            dataContext.ShoesPairList.Add(new ShoesPair(dataContext.ShoesDictionary[114], new decimal(450.0),
                            new decimal(0.22), 20, new decimal(0.1)));
            dataContext.ShoesPairList.Add(new ShoesPair(dataContext.ShoesDictionary[115], new decimal(350.0),
                            new decimal(0.22), 20, new decimal(0.1)));
            dataContext.ShoesPairList.Add(new ShoesPair(dataContext.ShoesDictionary[112], new decimal(400.0),
                          new decimal(0.22), 20, new decimal(0.0)));

            dataContext.TransactionCollection.Add(new Invoice(dataContext.ClientList[0], dataContext.ShoesPairList[0], 1,
                            new decimal(12.0)));
            dataContext.TransactionCollection.Add(new Invoice(dataContext.ClientList[1], dataContext.ShoesPairList[1], 1,
                            new decimal(12.0)));
            dataContext.TransactionCollection.Add(new Invoice(dataContext.ClientList[2], dataContext.ShoesPairList[2], 1,
                            new decimal(12.0)));
            dataContext.TransactionCollection.Add(new Invoice(dataContext.ClientList[3], dataContext.ShoesPairList[3], 1,
                            new decimal(12.0)));
            dataContext.TransactionCollection.Add(new Invoice(dataContext.ClientList[4], dataContext.ShoesPairList[4], 1,
                            new decimal(12.0)));
            dataContext.TransactionCollection.Add(new Invoice(dataContext.ClientList[0], dataContext.ShoesPairList[5], 1,
                          new decimal(12.0)));
        }
    }
}
