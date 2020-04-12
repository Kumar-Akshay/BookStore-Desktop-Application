using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BookInvertorySystem
{
    public partial class ucAdd : UserControl
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

        public ucAdd()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(titlebox.Text))
            {
                try
                {
                    con.Open();
                    var sql = "INSERT INTO [dbo].[Book] ([ISBN], [YEAR], [TITLE], [PRICE], [PUBLISHERNAME], [AUTHORNAME], [QUANTITY]) VALUES (@isbn, @year, @title,@price,@pname,@author,@qty)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = isbnbox.Text;
                        cmd.Parameters.Add("@year", SqlDbType.NVarChar).Value = yearbox.Text;
                        cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = titlebox.Text;
                        cmd.Parameters.Add("@price", SqlDbType.NVarChar).Value = pricebox.Text;
                        cmd.Parameters.Add("@pname", SqlDbType.NVarChar).Value = pbox.Text;
                        cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = authorbox.Text;
                        cmd.Parameters.Add("@qty", SqlDbType.NVarChar).Value = qtybox.Text;

                        int rowsAdded = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowsAdded > 0)
                        {
                            MessageBox.Show("Record Added!!" + rowsAdded);
                            isbnbox.Clear();
                            yearbox.Clear();
                            titlebox.Clear();
                            pricebox.Clear();
                            pbox.Clear();
                            authorbox.Clear();
                            qtybox.Clear();
                        }
                        else
                            MessageBox.Show("No row inserted");

                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    MessageBox.Show("ERROR:" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please Enter Title Name");
            }
        }
    }
}
