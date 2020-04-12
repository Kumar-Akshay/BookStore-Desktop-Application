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
    public partial class Form1 : Form
    {
        Customer customer = new Customer();
        Admin admin = new Admin();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true ;
            
         }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;

        }

        
        private void button4_Click_1(object sender, EventArgs e)
        {
            string email = textBox4.Text;
            string pass = textBox3.Text;
            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass))
            {
                bool check = admin.AdminLogin(email, pass);
                if (check)
                {
                    this.Hide();
                    CustomerDashboard P = new CustomerDashboard();
                    P.Show();
                }
                else
                {
                    MessageBox.Show("Email and Password are incorret");
                }
            }
            else
            {
                MessageBox.Show("Feids Can't be Empty");

            }
        }
           

        

        private void button5_Click(object sender, EventArgs e)
        {

            panel3.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Name = name.Text;
            string Email = email.Text;
            string Pass = password.Text;
            string Phone = phone.Text;
            string Address = address.Text;

            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Pass))
            {
                bool check =customer.CustomerRegistration(Name, Email, Pass, Phone, Address);
                if (check)
                {
                    name.Clear();
                    email.Clear();
                    password.Clear();
                    phone.Clear();
                    address.Clear();
                    MessageBox.Show("User Succesfully Register");
                }
                else
                {
                    name.Clear();
                    email.Clear();
                    password.Clear();
                    phone.Clear();
                    address.Clear();
                    MessageBox.Show("User Not Register");
                }


            }
            else
            {
                MessageBox.Show("Feilds Empty");
            }

        }

        //User login Requiered
        private void button3_Click_1(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            string pass  = textBox2.Text;
            bool check = customer.CustomerLogin(Email,pass);
            if (check)
            {
                UserPanel C = new UserPanel();
                this.Hide();
                C.Show();

            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Email and Password Incorret");

            }
        }
    }
}
