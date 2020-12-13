using ConsoleSerializer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ConsoleSerializer.Serializer.Tests
{
    [TestClass()]
    public class CustomSerializerTests
    {
        private ClassA classA;
        private ClassB classB;
        private ClassC classC;
        private string filePath = Directory.GetCurrentDirectory() + "\\customSerialized.txt";

        public CustomSerializerTests()
        {
            classA = new ClassA("Anna", "Kowalska", 24, 160.5);
            classB = new ClassB("Jan", "Kowalski", 54, 180.5);
            classC = new ClassC("Hermenegilda", "Nowak", 66, 157.5);
            classA.B = classB;
            classB.C = classC;
            classC.A = classA;

        }

        [TestMethod()]
        public void DeserializeClassAObjectTest()
        {
            CustomSerializer serializer = new CustomSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, classA);

            }
            CustomSerializer deserializer = new CustomSerializer();
            ClassA resultObject = null;
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                resultObject = (ClassA)deserializer.Deserialize(stream);
            }

            Assert.IsNotNull(resultObject);
            Assert.AreEqual("Anna", resultObject.Name);
            Assert.AreEqual("Kowalska", resultObject.LastName);
            Assert.AreEqual(24, resultObject.Age);
            Assert.AreEqual(160.5, resultObject.Height);
            Assert.AreEqual(classB, resultObject.B);
        }

        [TestMethod()]
        public void SerializeClassAObjectTest()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\customSerialized.txt";
            CustomSerializer serializer = new CustomSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, classA);

            }
            FileInfo info = new FileInfo(filePath);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 300);
        }

        [TestMethod()]
        public void DeserializeClassBObjectTest()
        {
            CustomSerializer serializer = new CustomSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, classB);

            }
            CustomSerializer deserializer = new CustomSerializer();
            ClassB resultObject = null;
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                resultObject = (ClassB)deserializer.Deserialize(stream);
            }

            Assert.IsNotNull(resultObject);
            Assert.AreEqual("Jan", resultObject.Name);
            Assert.AreEqual("Kowalski", resultObject.LastName);
            Assert.AreEqual(54, resultObject.Age);
            Assert.AreEqual(180.5, resultObject.Height);
            Assert.AreEqual(classC, resultObject.C);
        }

        [TestMethod()]
        public void SerializeClassBObjectTest()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\customSerialized.txt";
            CustomSerializer serializer = new CustomSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, classB);

            }
            FileInfo info = new FileInfo(filePath);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 300);
        }

        [TestMethod()]
        public void DeserializeClassCObjectTest()
        {
            CustomSerializer serializer = new CustomSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, classC);

            }
            CustomSerializer deserializer = new CustomSerializer();
            ClassC resultObject = null;
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                resultObject = (ClassC)deserializer.Deserialize(stream);
            }

            Assert.IsNotNull(resultObject);
            Assert.AreEqual("Hermenegilda", resultObject.Name);
            Assert.AreEqual("Nowak", resultObject.LastName);
            Assert.AreEqual(66, resultObject.Age);
            Assert.AreEqual(157.5, resultObject.Height);
            Assert.AreEqual(classA, resultObject.A);
        }

        [TestMethod()]
        public void SerializeClassCObjectTest()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\customSerialized.txt";
            CustomSerializer serializer = new CustomSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, classC);

            }
            FileInfo info = new FileInfo(filePath);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 300);
        }
    }
}