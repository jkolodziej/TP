using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleSerializer.Serializer
{
    class BinarySerializer
    {
        public void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            binaryFormatter.Serialize(fileStream, data);
            fileStream.Close();

        }

        public object BinaryDeserialize(string filePath)
        {
            object obj = null;
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }
            return obj;
        }
    }
}
