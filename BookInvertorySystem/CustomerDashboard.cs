using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BookInvertorySystem
{
    public partial class CustomerDashboard : Form
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        private Purchase purchase = new Purchase();
        private ucAdd add = new ucAdd();
        private ucSearch search = new ucSearch();
        private ucUpdate update = new ucUpdate();
        private ucPurchase p = new ucPurchase();

        public CustomerDashboard()
        {
            InitializeComponent();
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
           
            panel3.Controls.Add(search);
            search.Show();

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(search);
            search.Show();
            search.BringToFront();

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(add);
            add.Show();
            add.BringToFront();

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(update);
            update.Show();
            update.BringToFront();

        }

        private void PurchaseBtn_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(p);
            p.Show();
            p.BringToFront();

        }
    }
}
