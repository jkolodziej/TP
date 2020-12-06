using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using ConsoleSerializer.Data;
using ConsoleSerializer.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SerializationUnitTests
{
    [TestClass]
    public class XmlSerializationTests
    {
        [TestMethod]
        public void TransactionSerializationTest()
        {
            Client client = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            Shoes shoes1 = new Shoes("CX123", 39, "Adidas", "female");
            Shoes shoes2 = new Shoes("VB453", 42, "Nike", "male");
            List<ShoesPair> shoesPairs = new ArrayList<ShoesPair>();
            ShoesPair shoesPair1 = new ShoesPair(shoes1, new decimal(300.0), new decimal(0.22), 20, new decimal(0.1));
            ShoesPair shoesPair2 = new ShoesPair(shoes2, new decimal(400.0), new decimal(0.22), 20, new decimal(0.2));
            ShoesPair shoesPair3 = new ShoesPair(shoes1, new decimal(300.0), new decimal(0.22), 19, new decimal(0.1));
            shoesPairs.Add(shoesPair1);
            shoesPairs.Add(shoesPair2);
            shoesPairs.Add(shoesPair3);
            TransactionRecord
            //Transaction transaction = new Return(client, shoesPair, 1);
            Transaction transaction = new Invoice(client, shoesPairs, 1, new decimal(12.0));
            string filePath = "C:\\Users\\Xarria\\source\\repos\\jkolodziej\\TP\\Zadanie2\\transaction.xml";
            //string filePath = "C:\\Users\\julka\\source\\repos\\TP1\\Zadanie2\\transaction.xml";
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
        }
    }
}
