using ConsoleSerializer.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ConsoleSerializer.Serializer
{
    public class CustomSerializerOLD : IFormatter
    { 
        private List<PropertyInfo> values = new List<PropertyInfo>();
    
        public ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Type type;

        public CustomSerializerOLD(Type type)
        {
            this.type = type;
        }

        public object Deserialize(Stream serializationStream)
        {
            Object obj = Activator.CreateInstance(type);

            using (var streamReader = new StreamReader(serializationStream))
            {              
                // read type name
                string typeName = streamReader.ReadLine();

                // read other content
                string content = streamReader.ReadToEnd();

                // fetch key : value pairs
                List<string> keyValuePairs = content.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string key, value;
                foreach (string pair in keyValuePairs)
                {
                    string[] keyValue = pair.Split(':');
                    key = keyValue[0];
                    value = keyValue[1];

                    PropertyInfo propertyInfo = type.GetProperty(key);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(obj, value);
                    }
                }
            }                      
            return obj;
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            List<PropertyInfo> properties = type.GetProperties().ToList();
            StreamWriter streamWriter = new StreamWriter(serializationStream);
            streamWriter.WriteLine(type.Name);
           foreach (PropertyInfo propertyInfo in properties)
            {
                // formaty( propertyName:propertyValue)
                streamWriter.WriteLine(String.Format("{0}:{1}", propertyInfo.Name, propertyInfo.GetValue(graph)));
            }
            //save changes
            streamWriter.Flush();
        }

        public void CustomSerialize(Type dataType, object data, string filePath)
        {
            CustomSerializerOLD customSerializer = new CustomSerializerOLD(dataType);
            if(File.Exists(filePath)) File.Delete(filePath);
            FileStream fileStream = File.Create(filePath);
            customSerializer.Serialize(fileStream, data);
            fileStream.Close();
        }

        public object CustomDeserialize(Type dataType, string filePath)
        {
            object obj = null;
            CustomSerializerOLD customSerializer = new CustomSerializerOLD(dataType);
            if (File.Exists(filePath))
            {
                FileStream fileStream = File.OpenRead(filePath);
                obj = customSerializer.Deserialize(fileStream);
                fileStream.Close();
            }
            return obj;
        }
    }
}
