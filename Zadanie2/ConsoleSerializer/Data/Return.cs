using System;
using System.Runtime.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    public class Return : Transaction, ISerializable 
    {
        public Return(Client client, ShoesPair shoesPair, int count) : base(client, shoesPair, count)
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
                return this.Client.Equals(i.Client) && this.ShoesPair.Equals(i.ShoesPair)
                        && this.Count.Equals(i.Count) && this.Date.Equals(i.Date);

            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
