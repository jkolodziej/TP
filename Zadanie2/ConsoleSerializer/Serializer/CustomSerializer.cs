using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleSerializer.Serializer
{
    public class CustomSerializer : Formatter
    {
        public override ISurrogateSelector SurrogateSelector { get; set; }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        public StringBuilder Builder;

        private List<string> readLines;

        public CustomSerializer()
        {
            Binder = new CustomBinder();
            Builder = new StringBuilder();
            readLines = new List<string>();
        }

        public override object Deserialize(Stream serializationStream)
        {
            Dictionary<int, object> deserialized = new Dictionary<int, object>();
            Dictionary<int, Tuple<Type, string, int, SerializationInfo>> references = new Dictionary<int, Tuple<Type, string, int, SerializationInfo>>();
            StreamingContext context = new StreamingContext(StreamingContextStates.File);
            object deserializedObject = null;
            SerializationInfo serializationInfo = null;
            int id = 0;

            using (StreamReader reader = new StreamReader(serializationStream))
            {
                while (!reader.EndOfStream)
                {
                    readLines.Add(reader.ReadLine());
                }
            }

            for (int i = 0; i < readLines.Count; i++)
            {
                if (readLines[i].Contains("Culture=neutral, PublicKeyToken=null"))
                {
                    string[] values = readLines[i].Split(':');
                    Type type = Binder.BindToType(values[0], values[1]);
                    id = int.Parse(values[2]);
                    serializationInfo = new SerializationInfo(type, new FormatterConverter());
                    object objectOfExpectedType = FormatterServices.GetUninitializedObject(type);
                    deserialized.Add(id, objectOfExpectedType);

                    if (deserializedObject == null)
                    {
                        deserializedObject = objectOfExpectedType;
                    }
                }
                else
                {
                    List<string> properties = readLines[i].Split(':').ToList();
                    Type propertyType = Type.GetType(properties[0]);
                    string propertyName = properties[1];
                    string propertyValue = properties[2];

                    if (propertyValue.Contains("reference"))
                    {
                        int reference = int.Parse(propertyValue.First().ToString());
                        references.Add(id, Tuple.Create(propertyType, propertyName, reference, serializationInfo));
                    }
                    else
                    {
                        serializationInfo.AddValue(propertyName, Convert.ChangeType(propertyValue, propertyType, CultureInfo.InvariantCulture), propertyType);
                    }
                }
            }

            foreach (var reference in references)
            {
                var tuple = reference.Value;
                tuple.Item4.AddValue(tuple.Item2, deserialized[tuple.Item3], tuple.Item1);
            }

            for (int i = 1; i <= deserialized.Count; i++)
            {
                Type[] constrTypes = { typeof(SerializationInfo), typeof(StreamingContext) };
                object[] constrArgs = { references[i].Item4, context };
                deserialized[i].GetType().GetConstructor(constrTypes).Invoke(deserialized[i], constrArgs);
            }
            return deserializedObject;
        }


        public override void Serialize(Stream serializationStream, object graph)
        {
            ISerializable data = (ISerializable)graph;
            SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            StreamingContext context = new StreamingContext(StreamingContextStates.File);

            Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);
            Builder.Append(assemblyName + ":" + typeName + ":" + m_idGenerator.GetId(graph, out bool firstTime).ToString() + "\n");

            data.GetObjectData(info, context);

            foreach (SerializationEntry item in info)
                this.WriteMember(item.Name, item.Value);

            while (m_objectQueue.Count != 0)
            {
                Serialize(null, m_objectQueue.Dequeue());
            }

            if (serializationStream != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(serializationStream))
                {
                    streamWriter.Write(Builder.ToString());
                }
            }
        }

        protected override void WriteDouble(double val, string name)
        {
            Builder.Append(val.GetType() + ":" + name + ":" + val.ToString(CultureInfo.InvariantCulture) + "\n");
        }

        protected override void WriteInt32(int val, string name)
        {
            Builder.Append(val.GetType() + ":" + name + ":" + val.ToString(CultureInfo.InvariantCulture) + "\n");

        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (obj != null)
            {
                if (!memberType.Equals(typeof(String)))
                {
                    Builder.Append(obj.GetType() + ":" + name + ":" + m_idGenerator.GetId(obj, out bool firstTime).ToString() + "_reference" + "\n");
                    if (firstTime)
                    {
                        m_objectQueue.Enqueue(obj);
                    }
                }
                else
                {
                    Builder.Append(obj.GetType() + ":" + name + ":" + (string)obj + "\n");
                }
            }
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
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
