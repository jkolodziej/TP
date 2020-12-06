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
    public class CustomSerializer : Formatter
    { 
        private List<PropertyInfo> values = new List<PropertyInfo>();
    
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Type type;

        public CustomSerializer(Type type)
        {
            this.type = type;
        }

        public object Deserialize(Stream serializationStream, Type objType)
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
                        propertyInfo.SetValue(obj, value, null);
                    }
                }
            }                      
            return obj;
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            ISerializable data = (ISerializable)graph;
            SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            StreamingContext context = new StreamingContext(StreamingContextStates.File);
            data.GetObjectData(info, context);
            foreach (SerializationEntry item in info)
                this.WriteMember(item.Name, item.Value);

            using (StreamWriter streamWriter = new StreamWriter(serializationStream))
            {
                foreach (PropertyInfo value in values)
                {
                    streamWriter.WriteLine(String.Format("{0}:{1}", value.Name, value.GetValue(graph)));
                }
            }
        }

        public void CustomSerialize(Type dataType, object data, string filePath)
        {
            CustomSerializer customSerializer = new CustomSerializer(dataType);
            if(File.Exists(filePath)) File.Delete(filePath);
            FileStream fileStream = File.Create(filePath);
            customSerializer.Serialize(fileStream, data);
            fileStream.Close();
        }

        public object CustomDeserialize(Type dataType, string filePath)
        {
            object obj = null;
            CustomSerializer customSerializer = new CustomSerializer(dataType);
            if (File.Exists(filePath))
            {
                FileStream fileStream = File.OpenRead(filePath);
                obj = customSerializer.Deserialize(fileStream, dataType);
                fileStream.Close();
            }
            return obj;
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            values.Add(val);
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            values.Add(new PropertyInfo());
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            values.Add(new PropertyInfo();
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            values.Add(new PropertyInfo());
        }

        public override object Deserialize(Stream serializationStream)
        {
            throw new NotImplementedException();
        }
    }
}
