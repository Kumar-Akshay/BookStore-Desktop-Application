using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BookInvertorySystem
{
    public class Customer
    {
        private SqlConnection con;

        public Customer()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

        }

        public bool CustomerLogin(string email, string pass)
        {
            SqlCommand cmd = new SqlCommand("select count (*) as cnt from Customer where EMAIL=@email and PASSWORD=@pwd", con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", pass);
            con.Open();
            if (cmd.ExecuteScalar().ToString() == "1")
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }


        }


        public bool CustomerRegistration(string Name, string Email, string Pass, string Phone, string Address)
        {
                var sql = "INSERT INTO [dbo].[Customer] ([NAME], [EMAIL], [PASSWORD], [PHONE], [ADDRESS]) VALUES (@name, @email, @password,@phone,@address)";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@password", Pass);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.Parameters.AddWithValue("@address", Address);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i!=0)
                return true;
                else
                return false;
                
        }

        }
    }

