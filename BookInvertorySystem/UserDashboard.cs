using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookInvertorySystem
{
    public partial class UserPanel : Form
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        private Book bookObj = new Book();
        private Purchase PurObj = new Purchase();
        private int sum = 0;
        private int count = 0;
        public UserPanel()
        {
            InitializeComponent();
        }

        private void SearchInventory_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                string bookname = textBox1.Text;
                DataTable dt = bookObj.SearchBook(bookname);
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

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql;
            SqlDataReader reader;
            object isbn = comboBox1.SelectedValue;
            int Id = Convert.ToInt32(isbn);
            if (Id != 0)
            {
                sql = new SqlCommand("select * from BOOK Where isbn =(" + Id + ")", con);
                reader = sql.ExecuteReader();
                reader.Read();
                label13.Text = reader["ISBN"].ToString();
                label12.Text = reader["TITLE"].ToString();

                panel3.Visible = true;

                reader.Close();


            }
            else
            {

            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            string book = label12.Text.ToString();
            int ISBN = Convert.ToInt32(label13.Text.ToString());
            DateTime IssueTime = IssueDatepicker.Value;
            string user = User.Text.ToString();
            if (!String.IsNullOrEmpty(user))
            {
                bool check = bookObj.BooKIssue(ISBN, book, IssueTime, user);
                if (check)
                {
                    MessageBox.Show("Book Issue to " + user);
                }
                else
                {
                    MessageBox.Show("Book Not Issue Succesfully");
                }
            }
            else
            {
                MessageBox.Show("Customer Name must include");
            }






        }

        private void IssueBtn_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel5.Visible = false;
            IssuePanel.Visible = true;
            panel4.Visible = false;
            panel3.Visible = false;
            SqlDataAdapter da = new SqlDataAdapter("Select isbn,title from Book", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Book Name--" };
            dt.Rows.InsertAt(dr, 0);
            comboBox1.ValueMember = "isbn";
            comboBox1.DisplayMember = "title";
            comboBox1.DataSource = dt;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            IssuePanel.Visible = false;
            panel4.Visible = false;
            label4.Visible = true;
            textBox1.Visible = true;
            SearchInventory.Visible = true;
        }

        private void purchasebtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel5.Visible = false;
            IssuePanel.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            SearchInventory.Visible = false;
            panel4.Visible = true;
            
            

            SqlDataAdapter da = new SqlDataAdapter("Select isbn,title from Book", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "Select Book Name" };
            dt.Rows.InsertAt(dr, 0);
            comboBox2.ValueMember = "isbn";
            comboBox2.DisplayMember = "title";
            comboBox2.DataSource = dt;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql;
            SqlDataReader reader;

            object isbn = comboBox2.SelectedValue;
            int Id = Convert.ToInt32(isbn);
            if (Id != 0)
            {
                sql = new SqlCommand("select * from BOOK Where isbn =(" + Id + ")", con);
                reader = sql.ExecuteReader();
                reader.Read();
                
                int Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                if (Quantity == 0)
                {
                    MessageBox.Show("Select Book is out of stock");
                }
                else
                {
                    bookpricelabel.Text = reader["PRICE"].ToString();
                    booknamelabel.Text = reader["TITLE"].ToString();
                }
                //bookqtylabel.Text = reader["Quantity"].ToString();
                if(bookqtycombo.Text == "Select Quantity")
                { }
                else
                {
                    bookqtycombo.SelectedText = "Select Quantity";
                }



                if (bookqtycombo.SelectedIndex == -1)
                {
                    bookqtycombo.Items.Clear();

                    for (int i = 1; i <= Quantity; i++)
                        bookqtycombo.Items.Add(i);
                }
                    // comboBox2.ValueMember = "Quantity";
                    // comboBox2.DisplayMember = "Quantity";
                    // comboBox2.DataSource = dt;

                booknamelabel.Visible = true;
                bookqtycombo.Visible = true;
                bookpricelabel.Visible = true;
                
                reader.Close();
            }
        }

        private void addtocartbtn_Click(object sender, EventArgs e)
        {
            string book = booknamelabel.Text;
            string qty = bookqtycombo.Text;
           

            if (!String.IsNullOrEmpty(qty))
            {
                if (qty != "Select Quantity")
                {


                   

                    int qtyno = Convert.ToInt32(bookqtycombo.Text);
                    int price = Convert.ToInt32(bookpricelabel.Text);
                    int totalprice = qtyno * price;
                    sum = totalprice + sum;
                    amountlabel.Text = sum.ToString();
                    dataGridView2.Rows.Add(book, qtyno, totalprice);
                    bookObj.getbookqty(qtyno,book);
                    label16.Visible = true;
                    amountlabel.Visible = true;


                    

                    bookqtycombo.SelectedIndex = -1;
                    

                    count++;
                }
                else
                {
                    MessageBox.Show("Please Select Quantity");
                }
            }
            else
            {
                MessageBox.Show("Please Select Book First ");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0) { 
            panel5.Visible = true;
            totalprice.Text = amountlabel.Text;
            totalprice.Visible = true;
                comboBox3.SelectedText = "Select";
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Online");
                comboBox3.Items.Add("In Store");


            }
            else
            {
                MessageBox.Show("Please Add Products in Add to cart");
            }


        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usernamebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string card = cardnumberbox.Text;
            string user = usernamebox.Text;
            string ship = addressbox.Text;
            string purchaseon = comboBox3.Text;

            if (!string.IsNullOrEmpty(card) && !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(ship) ) { 
            int count = dataGridView2.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                card = cardnumberbox.Text;
                user = usernamebox.Text;
                ship = addressbox.Text;
                purchaseon = comboBox3.Text;
                string bookname = dataGridView2.Rows[i].Cells[0].Value.ToString();
                int qty = Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value.ToString());
                int price = Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value.ToString());
                bool check = PurObj.UserPurchase(card, user, ship, purchaseon, bookname, qty, price);
                    if (check)
                    {
                        MessageBox.Show("Succesfully Purchase");
                    }
                    else
                    {
                        MessageBox.Show("Unsuccesfully to Purchase");
                    }
                    
            }
            }
            else
            {
                MessageBox.Show("Please Show All Details");
            }






        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            this.Hide();
            F.Show();
        }
    }
}
