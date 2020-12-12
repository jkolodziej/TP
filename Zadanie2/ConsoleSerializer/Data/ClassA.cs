﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSerializer.Data
{
    public class ClassA : ISerializable
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public int Age { get; set; }
        [DataMember] public double Height { get; set; }
        [DataMember] public ClassB B { get; set; }

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
            return "Name: " + Name + "\nLastName: " + LastName + "\nAge: " + Age + "\nHeight: " + Height + "\nClassB: " + B.GetType().Name;
        }
    }


}
