using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlStoreDAORepository : IStoreDAORepository
    {
        readonly SqlContext db;
        public SqlStoreDAORepository(SqlContext db)
        {
            this.db = db;
        }

        public async Task<StoreDAO> GetFromReader(SqlDataReader rdr)
        {
            return new StoreDAO
            {
                ID=Convert.ToInt32(rdr["ID"]),
                Name= Convert.ToString(rdr["Name"]),
                Address = Convert.ToString("Address"),
                Owner=await new SqlOwnerDAORepository(new SqlContext())
                .GetByID(Convert.ToInt32(rdr["ID"])),
                StorePin = Convert.ToString(rdr["StorePin"])
            };
        }

        public async Task<StoreDAO> GetByID(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetStoreByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
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
