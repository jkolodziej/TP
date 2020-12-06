using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleSerializer.Serializer
{
    public class CustomFormatter : Formatter
    {
        private List<XElement> values = new List<XElement>();

        private Type type;

        public CustomFormatter(Type type)
        {
            this.type = type;
        }

        public override ISurrogateSelector SurrogateSelector { get; set; }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }

        public override object Deserialize(Stream serializationStream)
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
            //StreamReader streamReader = new StreamReader(serializationStream);
           // Console.WriteLine(streamReader.Read());
            return obj;

        }
//       using (StreamReader reader = new StreamReader(serializationStream))
//            {
//                SerializationInfo serializationInfo = new SerializationInfo(typeof(PurchaseRecord), new FormatterConverter());
//    string line = reader.ReadLine();
//                while (line != null)
//                {
//                    string[] splitLine = line.Split("_ ");
//                    if (splitLine.Length > 2)
//                    {
//                        for (int i = 1; i<splitLine.Length; i++)
//                        {
//                            splitLine[1] += splitLine[i];
//                        }
//                    }
//                    serializationInfo.AddValue(splitLine[0] + "_", splitLine[1]);
//line = reader.ReadLine();
//                }
//                purchaseRecord = new PurchaseRecord(serializationInfo);

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
                foreach (XElement value in values)
                {
                    streamWriter.WriteLine(String.Format("{0}:{1}", value.Name, value.Value));
                }
            }

            //foreach (XElement value in values)
            //{
            //    streamWriter.WriteLine(String.Format("{0}:{1}", value.Name, value.Value));
            //}
            //save changes



            //XmlWriter writer = XmlWriter.Create(serializationStream);
            //XDocument xmlDocument = new XDocument(new XElement("Serialization", values));
            //xmlDocument.Save(writer);
            //writer.Flush();
        }

        public void CustomSerialize(Type dataType, object data, string filePath)
        {
            CustomFormatter customFormatter = new CustomFormatter(dataType);
            if (File.Exists(filePath)) File.Delete(filePath);
            FileStream fileStream = File.Create(filePath);
            customFormatter.Serialize(fileStream, data);
            fileStream.Close();
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
            values.Add(new XElement(name, val));
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
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            values.Add(new XElement(name, obj.ToString()));
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
            values.Add(new XElement(name, obj.ToString()));
        }
    }
}
