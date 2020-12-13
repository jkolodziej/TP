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
        public void JsonSerializeTest()
        {
            JsonSerializer jsonSerializer3 = new JsonSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer3.JsonSerialize(fileStream, classA);
            }
            FileInfo info = new FileInfo(filePath);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 300);
        }

        [TestMethod()]
        public void JsonDeserializeTest()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer.JsonSerialize(fileStream, classA);
            }
            ClassA resultObject = null;
            resultObject = (ClassA)jsonSerializer.JsonDeserialize(filePath);

            Assert.IsNotNull(resultObject);
            Assert.AreEqual("Anna", resultObject.Name);
            Assert.AreEqual("Kowalska", resultObject.LastName);
            Assert.AreEqual(24, resultObject.Age);
            Assert.AreEqual(160.5, resultObject.Height);
            Assert.AreEqual(classB, resultObject.B);
            Assert.AreEqual(classC, resultObject.B.C);
        }
    }
}