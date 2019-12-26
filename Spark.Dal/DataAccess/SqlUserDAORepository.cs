using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlUserDAORepository : IUserDAORepository
    {
        readonly SqlContext db;
        public SqlUserDAORepository(SqlContext db)
        {
            this.db = db;
        }
        

        public async Task<UserDAO> GetFromReader(SqlDataReader rdr)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDAO> GetUser(string username)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetUserByUsername", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar,256).Value = username;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            var d = await GetFromReader(rdr);
                        }
                    }
                }
                con.Close();
                return null;
            }
        }

        public async Task<UserDAO> GetByID(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetUserByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
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
