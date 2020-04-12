using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookInvertorySystem
{
    public partial class ucPurchase : UserControl
    {
        private Book book = new Book();
        private DataTable dt = new DataTable();
        public ucPurchase()
        {
            InitializeComponent();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt = book.PurchaseDetails();
            dataGridView3.Visible = true;
            dataGridView3.DataSource = dt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dt = book.IssueDetails();
            dataGridView3.Visible = true;
            dataGridView3.DataSource = dt;
        }
    }
}
