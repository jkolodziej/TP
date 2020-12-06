using ConsoleSerializer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsoleSerializer.Serializer;
using ConsoleSerializer;
using System.IO;

namespace SerializationUnitTests
{
    [TestClass]
    public class XmlSerializerTests
    {
        Client client;
        Client client1;
        Shoes shoes;
        Shoes shoes1;
        List<ShoesPair> shoesPairs = new ArrayList<ShoesPair>();
        List<ShoesPair> shoesPairs1 = new ArrayList<ShoesPair>();
        ShoesPair shoesPair1;
        ShoesPair shoesPair2;
        ShoesPair shoesPair3;
        Invoice transaction1;
        Invoice transaction2;
        List<Invoice> transactions;
        TransactionRecord trecord;

        [TestInitialize]
        public void TestInitialize()
        {
            client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            client1 = new Client("Marian", "Nowak", "marian.nowak@gmail.com", "Pabianice Zamkowa 26a", "+4876556780");
            shoes = new Shoes("N123", 40, "Nike", "female");
            shoes1 = new Shoes("A345", 45, "Adidas", "male");
            shoesPairs = new ArrayList<ShoesPair>();
            shoesPair1 = new ShoesPair(shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            shoesPair2 = new ShoesPair(shoes1, new decimal(400.0), new decimal(0.22), 20, new decimal(0.1));
            shoesPair3 = new ShoesPair(shoes, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            shoesPairs.Add(shoesPair1);
            shoesPairs.Add(shoesPair2);
            shoesPairs1.Add(shoesPair3);
            transaction1 = new Invoice(client1, shoesPairs, 1, new decimal(10.0));
            transaction2 = new Invoice(client, shoesPairs1, 1, new decimal(12.0));
            transactions = new List<Invoice>();
            transactions.Add(transaction2);
            transactions.Add(transaction1);
            trecord = new TransactionRecord(transactions);
        }


        [TestMethod]
        public void XmlSerializeTest()
        {           
            string filePath = "C:\\Users\\Xarria\\source\\repos\\jkolodziej\\TP\\Zadanie2\\transactionRecord.xml";
            //string filePath = "C:\\Users\\julka\\source\\repos\\TP1\\Zadanie2\\transaction.xml";
            SerializeToXml serializeToXml = new SerializeToXml();
            TransactionRecord t = null;
            serializeToXml.XmlSerialize(typeof(TransactionRecord), trecord, filePath);           
            FileInfo info = new FileInfo(filePath);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 300);
        }

        [TestMethod]
        public void XmlDeserializeTest()
        {
            string filePath = "C:\\Users\\Xarria\\source\\repos\\jkolodziej\\TP\\Zadanie2\\transactionRecord.xml";
            //string filePath = "C:\\Users\\julka\\source\\repos\\TP1\\Zadanie2\\transaction.xml";
            SerializeToXml serializeToXml = new SerializeToXml();
            TransactionRecord t = null;
            serializeToXml.XmlSerialize(typeof(TransactionRecord), trecord, filePath);
            t = serializeToXml.XmlDeserialize(typeof(TransactionRecord), filePath) as TransactionRecord;
            Client c = t.Transactions[0].Client;
            Assert.IsNotNull(t);
            Assert.AreEqual(transactions.Count, t.Transactions.Count);
            Assert.AreEqual(transactions[0].TotalPrice, t.Transactions[0].TotalPrice);
            Assert.AreEqual(transactions[0].Client.Name, c.Name);
        }





    }
}
