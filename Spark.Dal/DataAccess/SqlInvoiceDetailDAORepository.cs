using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlInvoiceDetailDAORepository : IInvoiceDetailDAORepository
    {
        readonly SqlContext db;
        public SqlInvoiceDetailDAORepository(SqlContext db)
        {
            this.db = db;
        }

        public async Task<InvoiceDetailDAO> GetFromReader(SqlDataReader rdr)
        {
            return new InvoiceDetailDAO
            {
                ID = Convert.ToInt32(rdr["ID"]),
                Count = Convert.ToDouble(rdr["Count"]),
                Invoice = await new SqlInvoiceDAORepository(new SqlContext())
                .GetByID(Convert.ToInt32(rdr["InvoiceID"])),
                CurrentPrice = Convert.ToDouble(rdr["CurrentPrice"]),
                Product = await new SqlProductDAORepository(new SqlContext())
                .GetByID(Convert.ToInt32(rdr["ProductID"])),
                TotalSum = Convert.ToDouble(rdr["TotalSum"]),
                IsCanceled = Convert.ToBoolean(rdr["IsCanceled"])
            };
        }

        public async Task<InvoiceDetailDAO> GetByID(int id)
        {

            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetInvoiceDetailByID", con))
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

        public Task<bool> InsertOrUpdate(InvoiceDetailDAO obj)
        {
            return Task.Run<bool>(() =>
            {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    con.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_InsertOrUpdateInvoiceDetail", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = obj.ID;
                            cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = obj.Invoice.ID;
                            cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = obj.Product.ID;
                            cmd.Parameters.Add("@Count", SqlDbType.Float).Value = obj.Count;
                            cmd.Parameters.Add("@CurrentPrice", SqlDbType.Float).Value = obj.CurrentPrice;
                            cmd.Parameters.Add("@TotalSum", SqlDbType.Float).Value = obj.TotalSum;
                            cmd.Parameters.Add("@IsCanceled", SqlDbType.Bit).Value = obj.IsCanceled;
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
