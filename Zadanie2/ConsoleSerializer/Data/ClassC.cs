using System.Runtime.Serialization;

namespace ConsoleSerializer.Data
{
    public class ClassC : ISerializable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public ClassA A { get; set; }

        public ClassC(string name, string lastName, int age, double height)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Height = height;
        }

        public ClassC(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            LastName = info.GetString("LastName");
            Age = info.GetInt32("Age");
            Height = info.GetDouble("Height");
            A = (ClassA)info.GetValue("ClassA", typeof(ClassA));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("LastName", LastName);
            info.AddValue("Age", Age);
            info.AddValue("Height", Height);
            info.AddValue("ClassA", A);
        }

        public override string ToString()
        {
            return "Name: " + Name + "\nLastName: " + LastName + "\nAge: " + Age + "\nHeight: " + Height + "\nClassA: " + A.GetType().Name;
        }
    }
}
