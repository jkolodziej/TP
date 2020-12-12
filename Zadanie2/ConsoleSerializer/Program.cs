using ConsoleSerializer.Data;
using ConsoleSerializer.Serializer;
using System;
using System.IO;

namespace ConsoleSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            // custom serializer test
            CustomSerializer serializer = new CustomSerializer();
            ClassA classA = new ClassA("Anna", "Kowalska", 24, 160.5);
            ClassB classB = new ClassB("Jan", "Kowalski", 54, 180.5);
            ClassC classC = new ClassC("Anna", "Nowak", 66, 157.5);
            classA.B = classB;
            classB.C = classC;
            classC.A = classA;
            Console.WriteLine(Directory.GetCurrentDirectory());
            string filePath = Directory.GetCurrentDirectory() + "\\serializedCustom.txt";
            string xmlPath = Directory.GetCurrentDirectory() + "\\serializedXML.xml";
            //XML
            //serialize
            SerializeToXml serializeToXml = new SerializeToXml();
            using (FileStream fileStream = new FileStream(xmlPath, FileMode.Create))
            {
                serializeToXml.XmlSerialize(classA, xmlPath);
                Console.WriteLine("XML DONE");
            }

            //deserialize
            SerializeToXml deserializeFromXml = new SerializeToXml();
            ClassA res = null;
            using (FileStream fileStream = new FileStream(xmlPath, FileMode.Open))
            {
                res = (ClassA) deserializeFromXml.XmlDeserialize(typeof(ClassA), xmlPath);

                Console.WriteLine(res.ToString());
            }


            //CUSTOM
            // serialize
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, classB);
                Console.WriteLine("Done");
            }

            //deserialize
            CustomSerializer deserializer = new CustomSerializer();
            ClassB result = null;
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                result = (ClassB)deserializer.Deserialize(stream);
                Console.WriteLine("Deserialized");
            }

            Console.WriteLine(result);
            Console.WriteLine(result.C);
            Console.WriteLine(result.C.A);


            Console.ReadLine();
        }
    }
}
