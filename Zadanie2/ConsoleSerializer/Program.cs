using ConsoleSerializer.Data;
using ConsoleSerializer.Serializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            // BINARY SERIALIZATION TEST with transaction

            //Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            //Shoes shoes = new Shoes("ddd", 14, "sdsdd","female");
            //ShoesPair shoesPair = new ShoesPair(shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            ////Transaction transaction = new Return(client, shoesPair, 1);
            //Transaction transaction = new Invoice(client, shoesPair, 1, new decimal(12.0));
            //string filePath = "clientTest";
            //BinarySerializer binarySerializer = new BinarySerializer();
            //Transaction t = null;
            //binarySerializer.BinarySerialize(transaction, filePath);
            //if(transaction is Invoice)
            //{
            //t = binarySerializer.BinaryDeserialize(filePath) as Invoice;
            //}
            //else
            //{
            //    t = binarySerializer.BinaryDeserialize(filePath) as Return;
            //}

            // xml serializer test

            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            Shoes shoes = new Shoes("ddd", 14, "sdsdd", "female");
            List<ShoesPair> shoesPairs = new ArrayList<ShoesPair>();
            ShoesPair shoesPair1 = new ShoesPair(shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            ShoesPair shoesPair2 = new ShoesPair(shoes, new decimal(400.0), new decimal(0.22), 20, new decimal(0.1));
            ShoesPair shoesPair3 = new ShoesPair(shoes, new decimal(300.0),new decimal(0.22), 20, new decimal(0.1));
            shoesPairs.Add(shoesPair1);
            shoesPairs.Add(shoesPair2);
            shoesPairs.Add(shoesPair3);
            //Transaction transaction = new Return(client, shoesPair, 1);
            Transaction transaction = new Invoice(client, shoesPairs, 1, new decimal(12.0));
            string filePath = "C:\\Users\\julka\\source\\repos\\TP1\\Zadanie2\\transaction.xml";
            SerializeToXml serializeToXml = new SerializeToXml();
            Transaction t = null;
            //Client c = null;
            serializeToXml.XmlSerialize(typeof(Invoice), transaction, filePath);
            if (transaction is Invoice)
            {
                t = serializeToXml.XmlDeserialize(typeof(Invoice), filePath) as Invoice;
            }
            else
            {
                t = serializeToXml.XmlDeserialize(typeof(Return), filePath) as Return;
            }
            Console.WriteLine("sam client");
            Console.WriteLine(t.Client);
            

            Console.WriteLine(t);

            //////////////////////////////////////

            ///////////
            ///
            Console.WriteLine("A to custom ale formatter");
            ISerializable clientObj = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            //ISerializable transactionObj = new Invoice(client, shoesPair, 1, new decimal(12.0));
            Formatter customFormatter = new CustomFormatter();
            const string fileName = "C:\\Users\\julka\\source\\repos\\TP1\\Zadanie2\\client.txt";
            File.Delete(fileName);
            using (Stream stream = new FileStream(fileName, FileMode.Create))
                customFormatter.Serialize(stream, clientObj);
            FileInfo info = new FileInfo(fileName);
            string content = File.ReadAllText(fileName, Encoding.UTF8);
            Console.WriteLine(content);


            // custom serializer test

            Console.WriteLine("A to custom");
            Client customClient = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
           
            string customFilePath = "C:\\Users\\julka\\source\\repos\\TP1\\Zadanie2\\client.xml";
            CustomSerializer customSerializer = new CustomSerializer(typeof(Client));
            Client newClient = null;
            customSerializer.CustomSerialize(typeof(Client), client, customFilePath);
            newClient = customSerializer.CustomDeserialize(typeof(Client), customFilePath) as Client;


            Console.WriteLine(newClient);

            Console.ReadLine();
        }
    }
}
