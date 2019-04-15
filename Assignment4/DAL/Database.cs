using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class Database
    {
        public bool validateAdmin(string username, string password)
        {
            string connString = @"Data Source=.\SQLEXPRESS2012; initial Catalog=Assignment4; User Id=sa;Password=savechange; ";
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "Select * from dbo.Admin where Login= '" + username + "' AND password = '" + password + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public int saveNewUser(Users user)
        {
            int res = -1;
            string connString = @"Data Source=.\SQLEXPRESS2012; initial Catalog=Assignment4; User Id=sa;Password=savechange; ";
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                DateTime d = DateTime.Today;
                string query = "insert into dbo.users (Name,Login,Password,Gender,Address,Age,NIC,DOB,Cricket,Hockey,Chess,ImageName,CreatedOn) values('" + user.name + "','" + user.login + "','" + user.password + "','" + user.gender + "','" + user.address + "','" + user.age + "','" + user.NIC + "','" + user.date + "','" + user.cricket + "','" + user.hockey + "','" + user.chess + "','" + user.ImageName + "','" + d + "')";
                query = query + "; Select Scope_Identity()";
                SqlCommand cmd = new SqlCommand(query, con);
                int r = Convert.ToInt32( cmd.ExecuteScalar());
                if (r > -1)
                {
                    res = r;
                    return res;
                }
                else
                {
                    return res;
                }
            }
        }
    }
}
