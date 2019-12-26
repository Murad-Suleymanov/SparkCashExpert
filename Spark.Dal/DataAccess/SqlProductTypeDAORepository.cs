using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlProductTypeDAORepository : IProductTypeDAORepository
    {
        readonly SqlContext db;
        public SqlProductTypeDAORepository(SqlContext db)
        {
            this.db = db;
        }

        public async Task<ProductTypeDAO> GetFromReader(SqlDataReader rdr)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductTypeDAO> GetByID(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetProductTypeByID", con))
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
