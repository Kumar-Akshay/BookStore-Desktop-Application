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
    public class Book
    {
        public SqlConnection con;
        List<int> qtyls = new List<int>();
        List<string> booklist = new List<string>();
        public Book()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

        }
        public bool BooKIssue(int ISBN, string book, DateTime time, string user)
        {

            var sql = "INSERT INTO [dbo].[IssueDetails] ([ISBN], [BookName], [Issuedate], [IssueTo]) VALUES (@ISBN,@BOOK,@TIME,@USER)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ISBN", ISBN);
            cmd.Parameters.AddWithValue("@BOOK", book);
            cmd.Parameters.AddWithValue("@TIME", time);
            cmd.Parameters.AddWithValue("@USER", user);
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


        public bool BookUpdate()
        {
            return false;
        }

        public DataTable SearchBook(string title)
        {

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from BOOK where TITLE like ( '%" + title + "%')", con);
            da.Fill(dt);
           
            return dt;

        }
        public void getbookqty(int qty,string book)
        {
            booklist.Add(book);
            qtyls.Add(qty);
        }
        public void BookQuantity()
        {
            SqlCommand sql;
            SqlDataReader reader;
            List<int> orignalqty = new List<int>();
            foreach(string book in booklist)
            {
                sql = new SqlCommand("select QUANTITY from BOOK Where TITLE =(" + book + ")", con);
                reader = sql.ExecuteReader();
                reader.Read();
                int str = Convert.ToInt32(reader["QUANTITY"].ToString());
                orignalqty.Add(str);
            }

           
        }

        public DataTable PurchaseDetails()
        {

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from PurchaseDetails", con);
            da.Fill(dt);

            return dt;

        }

        public DataTable IssueDetails()
        {

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from IssueDetails", con);
            da.Fill(dt);

            return dt;

        }

    }
}
    
