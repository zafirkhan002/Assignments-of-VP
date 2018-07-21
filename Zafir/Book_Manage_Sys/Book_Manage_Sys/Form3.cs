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
    public partial class Form3 : Form
    {
        Form1 f1 = new Form1();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
              try{
            f1.sqlConnection1.Open();


            SqlCommand cmd = new SqlCommand("Update Login set Password=@Password where UserID  = '" + textBox1.Text + "'", f1.sqlConnection1);
              
            cmd.Parameters.AddWithValue("@Password", textBox3.Text);
            cmd.ExecuteNonQuery();
            f1.sqlConnection1.Close();
            MessageBox.Show("Password is changed now!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();

            }

            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
