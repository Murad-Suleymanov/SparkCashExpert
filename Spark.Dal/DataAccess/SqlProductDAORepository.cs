﻿using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlProductDAORepository : IProductDAORepository
    {
        readonly SqlContext db;
        public SqlProductDAORepository(SqlContext db)
        {
            this.db = db;
        }

        public async Task<ProductDAO> GetFromReader(SqlDataReader rdr)
        {
            return new ProductDAO
            {
                ID = Convert.ToInt32(rdr["ID"]),
                Barcode = Convert.ToString(rdr["Barcode"]),
                Count = Convert.ToDouble(rdr["Count"]),
                Name = Convert.ToString(rdr["Name"]),
                //ProductType = await new SqlProductTypeDAORepository(new SqlContext())
                //.GetByID(Convert.ToInt32(rdr["ProductType"])),
                PurschasePrice = Convert.ToDouble(rdr["PurchasePrice"]),
                SellPrice = Convert.ToDouble(rdr["SellPrice"])
            };
        }

        public async Task<ProductDAO> GetByID(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetProductById", con))
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

        public Task<List<ProductDAO>> GetProductsLikeBarcode(string barcode)
        {
            return Task.Run<List<ProductDAO>>(() =>
             {
                 var d = new List<ProductDAO>();
                 using (SqlConnection con = new SqlConnection(db.ConnectionString))
                 {
                     con.Open();
                     using (SqlCommand cmd = new SqlCommand("SP_GetProductsLikeBarcode", con))
                     {
                         cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 20).Value = barcode;
                         using (SqlDataReader rdr = cmd.ExecuteReader())
                         {
                             if (rdr.HasRows)
                             {
                                 while (rdr.Read())
                                 {
                                     var c = Task.Run<ProductDAO>(async () =>
                                     {
                                         var f = await GetFromReader(rdr);
                                         return f;
                                     }).GetAwaiter().GetResult();
                                     d.Add(c);
                                 }
                                 con.Close();
                                 return d;
                             }
                         }
                     }
                     return null;
                 }
             });
        }

        public Task<ProductDAO> GetByBarcode(string barcode)
        {
            return Task.Run<ProductDAO>(() =>
            {
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GetProductByBarcode", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 20).Value = barcode;
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                var c = Task.Run<ProductDAO>(async () =>
                                {
                                    var f = await GetFromReader(rdr);
                                    return f;
                                }).GetAwaiter().GetResult();
                                con.Close();
                                return c;
                            }
                        }
                    }
                    return null;
                }
            });
        }

        public Task<ObservableCollection<ProductDAO>> GetProductsLikeSearchString(string barcode)
        {
            return Task.Run<ObservableCollection<ProductDAO>>(() =>
            {
                var d = new ObservableCollection<ProductDAO>();
                using (SqlConnection con = new SqlConnection(db.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GetProductsLikeBarcode", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Barcode", barcode);
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    var c = Task.Run<ProductDAO>(async () =>
                                    {
                                        var f = await GetFromReader(rdr);
                                        return f;
                                    }).GetAwaiter().GetResult();
                                    d.Add(c);
                                }
                                con.Close();
                                return d;
                            }
                        }
                    }
                    return null;
                }
            });
        }
    }
}
