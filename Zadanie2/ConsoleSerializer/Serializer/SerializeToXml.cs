using System;
using System.Xml;
using System.Runtime.Serialization;

namespace ConsoleSerializer.Serializer
{
    public class SerializeToXml
    {
        public SerializeToXml() { }

        public object XmlDeserialize(Type dataType, string filePath)
        {
            object obj = null;
            DataContractSerializer dataContractSerializer = new DataContractSerializer(dataType);
            XmlReader reader = XmlReader.Create(filePath);
            obj = dataContractSerializer.ReadObject(reader);
            reader.Close();
            return obj;
        }

        public void XmlSerialize(Type dataType, object data, string filePath)
        {
            DataContractSerializer dataContractSerializer = new DataContractSerializer(dataType, null, int.MaxValue, false, true, null, null);
            using (XmlWriter xmlWriter = XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }))
            {
                dataContractSerializer.WriteObject(xmlWriter, data);
                xmlWriter.Close();
            }
        }
    }
}

