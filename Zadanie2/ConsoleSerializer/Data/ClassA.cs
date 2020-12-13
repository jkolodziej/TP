using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSerializer.Data
{
    public class ClassA : ISerializable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public ClassB B { get; set; }

        public ClassA () { }

        public ClassA(string name, string lastName, int age, double height)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Height = height;
        }

        public ClassA(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            LastName = info.GetString("LastName");
            Age = info.GetInt32("Age");
            Height = info.GetDouble("Height");
            B = (ClassB) info.GetValue("ClassB", typeof(ClassB));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("LastName", LastName);
            info.AddValue("Age", Age);
            info.AddValue("Height", Height);
            info.AddValue("ClassB", B);
        }

        public override string ToString()
        {
            return "\nA:" + "\nName: " + Name + "\nLastName: " + LastName + "\nAge: " + Age + "\nHeight: " + Height + "\nClassB: " + B.GetType().Name;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ClassA i = (ClassA)obj;
                return this.Name.Equals(i.Name) && this.LastName.Equals(i.LastName) && 
                    this.Age.Equals(i.Age) && this.Height.Equals(i.Height);;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


}
