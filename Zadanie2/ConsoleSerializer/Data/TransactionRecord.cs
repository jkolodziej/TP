using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    public class TransactionRecord : ISerializable
    {
        public List<Invoice> Transactions { get; set; }   

        public TransactionRecord(){}

        public TransactionRecord(List<Invoice> transactions)
        {
            Transactions = transactions;
           // TransactionsCount = transactions.Count;
        }

        protected TransactionRecord(SerializationInfo info, StreamingContext context)
        {
            Transactions = (List<Invoice>)info.GetValue("Transactions", typeof(List<Invoice>));
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
                TransactionRecord i = (TransactionRecord)obj;
                return this.Transactions.Equals(i.Transactions);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            //str.Append(TransactionsCount);
            foreach(Invoice invoice in Transactions)
            {
                str.Append(invoice.ToString());
            }
            return str.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("TransactionsCount", TransactionsCount);
            info.AddValue("Transactions", Transactions);
        }

    }
}
