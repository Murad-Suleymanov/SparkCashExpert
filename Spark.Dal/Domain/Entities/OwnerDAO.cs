﻿using Spark.Dal.Domain.Abstract;

namespace Spark.Dal.Domain.Entities
{
    public class OwnerDAO : IBaseDAO
    {
        public int ID { get; set; }
        public UserDAO User { get; set; }
        public int BankAccountNumber { get; set; }
    }
}
