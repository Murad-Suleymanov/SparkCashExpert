using Spark.Dal.Domain.Abstract;
using System;

namespace Spark.Dal.Domain.Entities
{
    public class InvoiceDAO : IBaseDAO
    {
        public int ID { get; set; }
        public int InvoiceType { get; set; }
        public UserDAO User { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceNumber { get; set; }
        public bool IsCanceled { get; set; }
    }
}
