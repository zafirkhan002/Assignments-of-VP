using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERP.project
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          // this.panel1.ResetText ="3E33E";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            textBox2.PasswordChar = '.';
            //this.BackColor = Color.BurlyWood;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 conn = new Form1();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Login where USERID = '" + textBox1.Text + "' and USERPAS='" + textBox2.Text + "' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("WELCOME TO MY ERP", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Password is not correct");
            }
            conn.oleDbConnection1.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
