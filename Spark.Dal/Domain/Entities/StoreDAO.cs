using Spark.Dal.Domain.Abstract;
using System;

namespace Spark.Dal.Domain.Entities
{
    public class StoreDAO : IBaseDAO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public OwnerDAO Owner { get; set; }
        public string Address { get; set; }
        public string StorePin { get; set; }
        public DateTime RegDate { get; set; }
        public UserDAO RegUser { get; set; }
    }
}
