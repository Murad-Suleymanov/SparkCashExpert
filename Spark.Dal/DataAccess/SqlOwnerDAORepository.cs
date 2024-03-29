﻿using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.DataAccess
{
    public class SqlOwnerDAORepository : IOwnerDAORepository
    {
        readonly SqlContext db;
        public SqlOwnerDAORepository(SqlContext db)
        {
            this.db = db;
        }


        public async Task<OwnerDAO> GetFromReader(SqlDataReader rdr)
        {
            return new OwnerDAO
            {
                ID = Convert.ToInt32(rdr["ID"]),
                User = await new SqlUserDAORepository(new SqlContext())
                .GetByID(Convert.ToInt32(rdr["UserID"])),
                BankAccountNumber = Convert.ToInt32(rdr["BankAccountNumber"])
            };
        }

        public async Task<OwnerDAO> GetByID(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetOwnerByID", con))
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
