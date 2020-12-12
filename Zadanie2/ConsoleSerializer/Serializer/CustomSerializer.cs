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
            throw new NotImplementedException();
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
