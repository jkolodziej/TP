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
            ClassA classA = new ClassA("Anna", "Kowalska", 24, 160.5);
            ClassB classB = new ClassB("Jan", "Kowalski", 54, 180.5);
            ClassC classC = new ClassC("Hermenegilda", "Nowak", 66, 157.5);
            classA.B = classB;
            classB.C = classC;
            classC.A = classA;
            char choice;
            do
            {
                Console.WriteLine("1. Custom serialization \n" +
                                  "2. Custom deserialization \n" +
                                  "3. Json serialization \n" +
                                  "4. Json deserialization \n" +
                                  "5. Finish \n");

                choice = Console.ReadKey().KeyChar;
                Console.ReadLine();
                switch (choice)
                {
                    case '1':
                        //CUSTOM serialize
                        string filePath1 = Directory.GetCurrentDirectory() + "\\customSerialized.txt";
                        CustomSerializer serializer1 = new CustomSerializer();
                        using (FileStream fileStream = new FileStream(filePath1, FileMode.Create))
                        {
                            serializer1.Serialize(fileStream, classA);

                        }
                        Console.WriteLine("\nSerialized to: " + filePath1);
                        break;
                    case '2':
                        //CUSTOM deserialize
                        string filePath2 = Directory.GetCurrentDirectory() + "\\customSerialized.txt";
                        CustomSerializer serializer2 = new CustomSerializer();
                        using (FileStream fileStream = new FileStream(filePath2, FileMode.Create))
                        {
                            serializer2.Serialize(fileStream, classA);

                        }                       
                        CustomSerializer deserializer = new CustomSerializer();
                        ClassA result2 = null;
                        using (Stream stream = File.Open(filePath2, FileMode.Open))
                        {
                            result2 = (ClassA)deserializer.Deserialize(stream);
                        }
                        Console.WriteLine("\nDeserialized (CUSTOM): \n" +
                                          result2 + "\n" +
                                          result2.B + "\n" +
                                          result2.B.C + "\n");
                        break;
                    case '3':
                        //JSON serialize
                        string filePath3 = Directory.GetCurrentDirectory() + "\\jsonSerialized.json";
                        JsonSerializer jsonSerializer3 = new JsonSerializer();
                        using (FileStream fileStream = new FileStream(filePath3, FileMode.Create))
                        {
                            jsonSerializer3.JsonSerialize(fileStream, classA);
                        }
                        Console.WriteLine("\nSerialized to: " + filePath3);
                        break;
                    case '4':
                        //JSON deserialize
                        string filePath4 = Directory.GetCurrentDirectory() + "\\jsonSerialized.json";
                        JsonSerializer jsonSerializer4 = new JsonSerializer();
                        using (FileStream fileStream = new FileStream(filePath4, FileMode.Create))
                        {
                            jsonSerializer4.JsonSerialize(fileStream, classA);
                        }
                        ClassA result4 = null;
                        result4 = (ClassA)jsonSerializer4.JsonDeserialize(filePath4);
                        Console.WriteLine("\nDeserialized (JSON): \n" +
                                          result4 + "\n" +
                                          result4.B + "\n" +
                                          result4.B.C + "\n");
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;

                }
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
                Console.Clear();
            } while (choice != '5');

            Console.ReadLine();
        }
    }
}
