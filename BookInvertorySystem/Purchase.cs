using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BookInvertorySystem
{
    public class Purchase
    {
        private SqlConnection con;

        public Purchase()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

        }
        public bool UserPurchase(string card, string user, string ship, string purchaseon, string book, int qty ,int price)
        {
            var sql = "INSERT INTO [dbo].[PurchaseDetails] ([CardNumber], [UserName], [Address],[PurchaseTime], [PurchaseOn], [Book],[Quantity],[Price]) VALUES (@card,@user,@ship,@Time,@purchaseon,@book,@qty,@price)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@card", card);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@ship", ship);
            cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
            cmd.Parameters.AddWithValue("@purchaseon", purchaseon);
            cmd.Parameters.AddWithValue("@book", book);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@price", price);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public DataTable ShowPurchase()
        {
          

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
           
            da = new SqlDataAdapter("select * from Purchase ", con);
            da.Fill(dt);


            return dt;

        }
    }
}
