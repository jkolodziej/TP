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
            string filePath = Directory.GetCurrentDirectory() + "\\serialized.txt";

            // serialize
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, classB);
                Console.WriteLine("Done");
            }

            Console.ReadLine();
        }
    }
}
