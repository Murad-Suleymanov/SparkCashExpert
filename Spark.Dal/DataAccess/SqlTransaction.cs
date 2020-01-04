using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlDbTransaction : ITransaction
    {
        SqlContext db = new SqlContext();

        public Task<bool> BeginTransactionAsync(InvoiceDAO invoiceDAO, ObservableCollection<InvoiceDetailDAO> detailDAOs)
        {
            return Task.Run<bool>(() =>
            {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    int modified = 0; int InvoiceID = 0;
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {

                        using (SqlCommand cmd = new SqlCommand("SP_InsertOrUpdateInvoice", con))
                        {
                            using (SqlCommand cmd1 = new SqlCommand("SP_InsertOrUpdateInvoiceDetail", con))
                            {
                                try
                                {
                                    #region InsertOrUpdateInvoice
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Transaction = transaction;

                                    #region Filling Invoice
                                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = invoiceDAO.ID;
                                    cmd.Parameters.Add("@InvoiceType", SqlDbType.Int).Value = invoiceDAO.InvoiceType;
                                    cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 128).Value = invoiceDAO.User.ID;
                                    cmd.Parameters.Add("@InvoiceDate", SqlDbType.Date).Value = invoiceDAO.InvoiceDate;
                                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceDAO.InvoiceNumber;
                                    cmd.Parameters.Add("@Canceled", SqlDbType.Bit).Value = invoiceDAO.IsCanceled;
                                    modified = Convert.ToInt32(cmd.ExecuteScalar());

                                    #endregion

                                    if (invoiceDAO.ID != 0)
                                        InvoiceID = invoiceDAO.ID;
                                    else
                                        InvoiceID = modified;

                                    #endregion

                                    #region InsertOrUpdateInvoiceDetail

                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Transaction = transaction;

                                    #region FillingInvoiceDetail

                                    foreach (var item in detailDAOs)
                                    {
                                        cmd1.Parameters.Add("@ID", SqlDbType.Int).Value = item.ID;
                                        cmd1.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID;
                                        cmd1.Parameters.Add("@ProductID", SqlDbType.Int).Value = item.Product.ID;
                                        cmd1.Parameters.Add("@Count", SqlDbType.Float).Value = item.Count;
                                        cmd1.Parameters.Add("@CurrentPrice", SqlDbType.Float).Value = item.CurrentPrice;
                                        cmd1.Parameters.Add("@TotalSum", SqlDbType.Float).Value = item.TotalSum;
                                        cmd1.Parameters.Add("@IsCanceled", SqlDbType.Bit).Value = item.IsCanceled;
                                        cmd1.ExecuteNonQuery();
                                        cmd1.Parameters.Clear();
                                    }

                                    #endregion

                                    #endregion
                                    transaction.Commit();
                                    return true;

                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                                finally
                                {
                                    con.Close();
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}
