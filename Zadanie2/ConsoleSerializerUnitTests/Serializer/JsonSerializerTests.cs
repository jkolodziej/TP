using ConsoleSerializer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ConsoleSerializer.Serializer.Tests
{
    [TestClass()]
    public class JsonSerializerTests
    {
        private ClassA classA;
        private ClassB classB;
        private ClassC classC;
        string filePath = Directory.GetCurrentDirectory() + "\\jsonSerialized.json";

        public JsonSerializerTests()
        {
            classA = new ClassA("Anna", "Kowalska", 24, 160.5);
            classB = new ClassB("Jan", "Kowalski", 54, 180.5);
            classC = new ClassC("Hermenegilda", "Nowak", 66, 157.5);
            classA.B = classB;
            classB.C = classC;
            classC.A = classA;
        }

        [TestMethod()]
        public void JsonSerializeClassAObjectTest()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer.JsonSerialize(fileStream, classA);
            }
            FileInfo info = new FileInfo(filePath);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 300);
        }

        [TestMethod()]
        public void JsonDeserializeClassAObjectTest()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer.JsonSerialize(fileStream, classA);
            }
            ClassA resultObject = null;
            resultObject = (ClassA)jsonSerializer.JsonDeserialize(filePath);

            Assert.IsNotNull(resultObject);
            Assert.AreEqual(classA, resultObject);
            Assert.AreEqual(classB, resultObject.B);
            Assert.AreEqual(classC, resultObject.B.C);
            Assert.AreSame(resultObject.B.C.A.B, resultObject.B);
            Assert.AreSame(resultObject.B.C.A.B.C, resultObject.B.C);
        }

        [TestMethod()]
        public void JsonSerializeClassBObjectTest()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer.JsonSerialize(fileStream, classB);
            }
            FileInfo info = new FileInfo(filePath);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 300);
        }

        [TestMethod()]
        public void JsonDeserializeClassBObjectTest()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer.JsonSerialize(fileStream, classB);
            }
            ClassB resultObject = null;
            resultObject = (ClassB)jsonSerializer.JsonDeserialize(filePath);

            Assert.IsNotNull(resultObject);
            Assert.AreEqual(classB, resultObject);
            Assert.AreEqual(classC, resultObject.C);
            Assert.AreEqual(classA, resultObject.C.A);
            Assert.AreSame(resultObject.C.A.B.C, resultObject.C);
            Assert.AreSame(resultObject.C.A.B.C.A, resultObject.C.A);
        }

        [TestMethod()]
        public void JsonSerializeClassCObjectTest()
        {
            JsonSerializer jsonSerializer3 = new JsonSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer3.JsonSerialize(fileStream, classC);
            }
            FileInfo info = new FileInfo(filePath);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 300);
        }

        [TestMethod()]
        public void JsonDeserializeClassCObjectTest()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer.JsonSerialize(fileStream, classC);
            }
            ClassC resultObject = null;
            resultObject = (ClassC)jsonSerializer.JsonDeserialize(filePath);

            Assert.IsNotNull(resultObject);
            Assert.AreEqual(classC, resultObject);
            Assert.AreEqual(classA, resultObject.A);
            Assert.AreEqual(classB, resultObject.A.B);
            Assert.AreSame(resultObject.A.B.C.A, resultObject.A);
            Assert.AreSame(resultObject.A.B.C.A.B, resultObject.A.B);
        }
    }
}