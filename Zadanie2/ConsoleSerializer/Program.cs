using ConsoleSerializer.Data;
using ConsoleSerializer.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            Shoes shoes = new Shoes("ddd", 14, "sdsdd","female");
            ShoesPair shoesPair = new ShoesPair(shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            //Transaction transaction = new Return(client, shoesPair, 1);
            Transaction transaction = new Invoice(client, shoesPair, 1, new decimal(12.0));
            string filePath = "clientTest";
            BinarySerializer binarySerializer = new BinarySerializer();
            //Client c = null;
            //Shoes s = null;
            Transaction t = null;
            //binarySerializer.BinarySerialize(client, filePath);
            //c = binarySerializer.BinaryDeserialize(filePath) as Client;
            //binarySerializer.BinarySerialize(shoes, filePath);
            //s = binarySerializer.BinaryDeserialize(filePath) as Shoes;
            binarySerializer.BinarySerialize(transaction, filePath);
            if(transaction is Invoice)
            {
            t = binarySerializer.BinaryDeserialize(filePath) as Invoice;
            }
            else
            {
                t = binarySerializer.BinaryDeserialize(filePath) as Return;
            }
           
            //Console.WriteLine(c.Name);
            //Console.WriteLine(c.Surname);
            //Console.WriteLine(c.EmailAddress);
            //Console.WriteLine(c.Address); 
            //Console.WriteLine(c.PhoneNumber);
            //Console.ReadLine();
            Console.WriteLine(t);

            Console.ReadLine();


        }
    }
}
