﻿using Spark.Dal.Domain.Abstract;
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


        public Task<UserDAO> GetFromReader(SqlDataReader rdr)
        {
            return Task.Run<UserDAO>(() =>
            {
                return new UserDAO
                {
                    ID = Convert.ToString(rdr["Id"]),
                    Name = Convert.ToString(rdr["Name"]),
                    Surname = Convert.ToString(rdr["Surname"]),
                    Patronmyc = Convert.ToString(rdr["Patronymc"]),
                    PasswordHash = Convert.ToString(rdr["PasswordHash"]),
                    UserName = Convert.ToString(rdr["UserName"])
                };
            });
        }

        public async Task<UserDAO> GetUser(string username)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetUserByUsername", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 256).Value = username;
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
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 128).Value = id.ToString();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            var d = GetFromReader(rdr).GetAwaiter().GetResult();
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
