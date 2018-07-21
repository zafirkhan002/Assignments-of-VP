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

namespace Book_Manage_Sys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox3.PasswordChar = '*';
        }

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form2 f2 = new Form2();
            //f2.Show();
            Form1 f1 = new Form1();
            f1.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select  Password from Login where UserID= '" + textBox1.Text + "'", f1.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
               
                MessageBox.Show("WELCOME TO KHAN BOOK STORE ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();

            }
            else
            {
                MessageBox.Show("Password is not correct !");
            }
        }
    }
}
