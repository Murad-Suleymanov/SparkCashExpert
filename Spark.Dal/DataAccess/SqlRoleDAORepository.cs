using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlRoleDAORepository : IRoleDAORepository
    {
        readonly SqlContext db;
        public SqlRoleDAORepository(SqlContext db)
        {
            this.db = db;
        }

        public async Task<RoleDAO> GetFromReader(SqlDataReader rdr)
        {
            return new RoleDAO
            {
                ID = Convert.ToString(rdr["Id"]),
                Name = Convert.ToString(rdr["Name"])
            };
        }

        public async Task<RoleDAO> GetByID(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetRoleById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 128).Value = id.ToString();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            var d = await GetFromReader(rdr);
                            con.Close();
                            return d;
                        }
                    }
                }
                con.Close();
                return null;
            }
        }

    }
}
