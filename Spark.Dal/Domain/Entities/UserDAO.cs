using System;

namespace Spark.Dal.Domain.Entities
{
    public class UserDAO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronmyc { get; set; }
        public DateTime CreateDate { get; set; }
        public string RegUser { get; set; }
        public DateTime LastActiveTime { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactoryEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccesFailedCount { get; set; }
        public string UserName { get; set; }
    }
}
