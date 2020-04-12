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
    public partial class ucUpdate : UserControl
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

        public ucUpdate()
        {
            InitializeComponent();
        }

        private void SearchBook_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from BOOK where TITLE like ( '%" + textBox2.Text + "%')", con);
                da.Fill(dt);
                int count = dt.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("Product Not Found");
                }
                else
                {
                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Enter Book Name To Edit");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                label14.Text = row.Cells[0].Value.ToString();

                textBox6.Text = row.Cells[1].Value.ToString();
                textBox8.Text = row.Cells[2].Value.ToString();
                textBox7.Text = row.Cells[3].Value.ToString();

                textBox5.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
                textBox3.Text = row.Cells[6].Value.ToString();



            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {

                var sql = "DELETE FROM [dbo].[Book] WHERE  ISBN=@isbn";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = label14.Text;
                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row == 1) { 
                    MessageBox.Show("Book Deleted Succesfully!!");
                    textBox6.Clear();
                    textBox8.Clear();
                    textBox7.Clear();
                    textBox5.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                    label14.Text = "";
                        dataGridView2.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Book Not Deleted Succesfully!!");

                    }

                }
            }



            catch (Exception ex)
            {
                // We should log the error somewhere, 
                // for this example let's just show a message
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "UPDATE [dbo].[Book] SET  YEAR=@year, TITLE=@title, PRICE=@price, PUBLISHERNAME=@pname, AUTHORNAME=@author, QUANTITY=@qty WHERE ISBN =@isbn ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = label14.Text;
                    cmd.Parameters.Add("@year", SqlDbType.NVarChar).Value = textBox6.Text;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = textBox8.Text;
                    cmd.Parameters.Add("@price", SqlDbType.NVarChar).Value = textBox7.Text;
                    cmd.Parameters.Add("@pname", SqlDbType.NVarChar).Value = textBox5.Text;
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = textBox4.Text;
                    cmd.Parameters.Add("@qty", SqlDbType.NVarChar).Value = textBox3.Text;

                    int rowsAdded = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAdded > 0)
                    {
                        MessageBox.Show("Record Updated Succesfully!!" + rowsAdded);
                        textBox6.Clear();
                        textBox8.Clear();
                        textBox7.Clear();
                        textBox5.Clear();
                        textBox4.Clear();
                        textBox3.Clear();
                        label14.Text = "";
                    }
                    else
                        MessageBox.Show("Record Not Updated");

                }
            }
            catch (Exception ex)
            {
                // We should log the error somewhere, 
                // for this example let's just show a message
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }
    }
}
