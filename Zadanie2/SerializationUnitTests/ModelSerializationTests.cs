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
    public class ModelSerializationTests
    {
        [TestMethod]
        public void ClientSerializationTest()
        {
            ISerializable clientObject = new Client("Jan", "Kowalski", "jan.kowalski@gmail.com", "Pabianice Zamkowa 23a", "+48123456780");
            CustomFormatter xmlSerializer = new CustomFormatter();
            const string fileName = "clientTest.xml";
            File.Delete(fileName);
            using (Stream stream = new FileStream("clientTest.xml", FileMode.Create))
                xmlSerializer.Serialize(stream, clientObject);
            FileInfo info = new FileInfo(fileName);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 200, $"The file length is {info.Length}");
            string content = File.ReadAllText(fileName, Encoding.UTF8);
            Debug.Write(content);
        }
    }
}
