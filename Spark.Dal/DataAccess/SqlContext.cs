using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlContext
    {
        private readonly string connectionString;

        public string ConnectionString => connectionString ?? "Server=.; Database=Spark; Integrated Security=SSPI;";
    }
}
