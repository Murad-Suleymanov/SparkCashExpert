using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;

namespace Spark.Dal.DataAccess
{
    public class SqlUserRoleDAORepository : IUserRoleDAORepository
    {
        readonly SqlContext db;
        public SqlUserRoleDAORepository(SqlContext db)
        {
            this.db = db;
        }

        public async Task<UserRoleDAO> GetFromReader(SqlDataReader rdr)
        {
            return new UserRoleDAO
            {
                Role= await new SqlRoleDAORepository(new SqlContext())
                .GetByID(Convert.ToInt32(rdr["RoleId"])),
                User = await new SqlUserDAORepository(new SqlContext())
                .GetByID(Convert.ToInt32(rdr["UserId"]))
            };
        }

        public async Task<UserRoleDAO> GetByID(int id)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetUserRoleByUserId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar,128).Value = id.ToString();
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

        public async Task<List<UserRoleDAO>> GetUserRoleWithUserID(UserDAO userDAO)
        {
            using (SqlConnection con = new SqlConnection(db.ConnectionString))
            {   
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetUserRoleByUserId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 128).Value = userDAO.ID;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        List<UserRoleDAO> roles = new List<UserRoleDAO>();
                        while (rdr.Read())
                        {
                            var d = await GetFromReader(rdr);
                            roles.Add(d);
                        }
                        con.Close();
                        return roles;
                    }
                }
                con.Close();
                return null;
            }
        }
    }
}
