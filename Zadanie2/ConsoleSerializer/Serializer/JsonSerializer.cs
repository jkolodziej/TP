using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace ConsoleSerializer.Serializer
{
    public class JsonSerializer
    {
        private JsonSerializerSettings settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            TypeNameHandling = TypeNameHandling.All,
        };

        public void JsonSerialize(Stream serializationStream, object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            serializationStream.Write(Encoding.UTF8.GetBytes(json), 0, Encoding.UTF8.GetBytes(json).Length);
        }

        public object JsonDeserialize(string filePath)
        {
            object obj = null;
            string json = File.ReadAllText(filePath);
            obj = JsonConvert.DeserializeObject(json, settings);
            return obj;
        }
    }
}
