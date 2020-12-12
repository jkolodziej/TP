using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsoleSerializer.Serializer
{
    public class SerializeToXml
    {
        public SerializeToXml() { }

        public object XmlDeserialize(Type dataType, string filePath)
        {
            object obj = null;                    
            if (File.Exists(filePath))
            {
                XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(filePath, new XmlDictionaryReaderQuotas());
                DataContractSerializer dataContractSerializer = new DataContractSerializer(dataType);
                obj = dataContractSerializer.ReadObject(xmlDictionaryReader, true);
                xmlDictionaryReader.Close();                
            }
            return obj;
        }

        public void XmlSerialize(object data, string filePath)
        {
            DataContractSerializer dataContractSerializer = new DataContractSerializer(data.GetType(), null, int.MaxValue, false, true, null, null);
            XmlWriter xmlWriter = xmlWriter.Create(filePath, new XmlWriterSettings() { indent = true });
            if (File.Exists(filePath)) File.Delete(filePath);
            dataContractSerializer.WriteObject(xmlWriter, data);
            xmlWriter.Close();
        }

        
    }
}
