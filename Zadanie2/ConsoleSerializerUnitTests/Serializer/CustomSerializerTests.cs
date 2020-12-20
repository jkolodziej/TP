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
            Assert.AreEqual(classA, resultObject);
            Assert.AreSame(resultObject.B.C.A.B, resultObject.B);
            Assert.AreSame(resultObject.B.C.A.B.C, resultObject.B.C);
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
            Assert.AreEqual(classB, resultObject);
            Assert.AreSame(resultObject.C.A.B.C, resultObject.C);
            Assert.AreSame(resultObject.C.A.B.C.A, resultObject.C.A);
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
            Assert.AreEqual(classC, resultObject);
            Assert.AreSame(resultObject.A.B.C.A, resultObject.A);
            Assert.AreSame(resultObject.A.B.C.A.B, resultObject.A.B);
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