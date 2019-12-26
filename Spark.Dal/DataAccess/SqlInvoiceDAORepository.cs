using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlInvoiceDAORepository : IInvoiceDAORepository
    {
        readonly SqlContext db;
        public SqlInvoiceDAORepository(SqlContext db)
        {
            this.db = db;
        }

        public async Task<InvoiceDAO> GetFromReader(SqlDataReader rdr)
        {
            return new InvoiceDAO
            {
                ID = Convert.ToInt32(rdr["ID"]),
                InvoiceDate = Convert.ToDateTime(rdr["InvoiceDate"]),
                InvoiceNumber = Convert.ToInt32(rdr["InvoiceNumber"]),
                InvoiceType = Convert.ToInt32(rdr["InvoiceType"]),
                IsCanceled = Convert.ToBoolean(rdr["Canceled"]),
                User = await new SqlUserDAORepository(new SqlContext()).GetByID(Convert.ToInt32(rdr["UserID"]))
            };
        }

        public async Task<InvoiceDAO> GetByID(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetInvoiceByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
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

        public Task<bool> InsertOrUpdate(InvoiceDAO obj)
        {
            return Task.Run<bool>(() =>
            {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    con.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_InsertOrUpdateInvoice", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = obj.ID;
                            cmd.Parameters.Add("@InvoiceType", SqlDbType.Int).Value = obj.InvoiceType;
                            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 128).Value = obj.User.ID;
                            cmd.Parameters.Add("@InvoiceDate", SqlDbType.Date).Value = obj.InvoiceDate;
                            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = obj.InvoiceNumber;
                            cmd.Parameters.Add("@Canceled", SqlDbType.Bit).Value = obj.IsCanceled;
                            cmd.ExecuteNonQuery();
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            });
        }
    }
}
