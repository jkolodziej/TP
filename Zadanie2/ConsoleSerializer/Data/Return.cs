using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    [XmlRoot("Return")]
    public class Return : Transaction, ISerializable 
    {
        public Return () { }

        public Return(Client client, List<ShoesPair> shoesPairs, int count) : base(client, shoesPairs, count)
        {
        }

        protected Return(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }


        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Return i = (Return)obj;
                return this.Client.Equals(i.Client) && this.ShoesPairs.Equals(i.ShoesPairs)
                        && this.Count.Equals(i.Count) && this.Date.Equals(i.Date);

            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
