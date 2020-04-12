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
    public partial class ucSearch : UserControl
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

        public ucSearch()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from BOOK where TITLE like ( '%" + textBox1.Text + "%')", con);
                da.Fill(dt);
                int count = dt.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("Product Not Found");
                }
                else
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Enter Book Name To Search");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
