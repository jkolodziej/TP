using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSerializer.Serializer
{
    public class JsonSerializer
    {
        public void JsonSerialize(Object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath)) File.Delete(filePath);
            StreamWriter sw = new StreamWriter(filePath);
           
        }

        public Object JsonDeserialize(string filePath)
        {
            Object obj = null;
            return obj;
        }
    }


}
