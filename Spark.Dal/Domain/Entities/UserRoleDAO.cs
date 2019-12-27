namespace Spark.Dal.Domain.Entities
{
    public class UserRoleDAO
    {
        public UserDAO User { get; set; }
        public RoleDAO Role { get; set; }
    }
}
