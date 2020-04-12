using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BookInvertorySystem
{
   
    public class Admin
    {
        private SqlConnection con;
        public Admin()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

        }

        public bool AdminLogin(string email,string pass)
        {
            SqlCommand cmd = new SqlCommand("select count (*) as cnt from Admin where EMAIL=@email and PASSWORD=@pwd", con);
            cmd.Parameters.Clear();
            con.Open();
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", pass);

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
    }
}
