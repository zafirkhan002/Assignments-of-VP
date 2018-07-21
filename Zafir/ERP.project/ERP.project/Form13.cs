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
    public partial class Form13 : Form
    {
        Form1 conn = new Form1();
        public Form13()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();

               }        
        

        private void Form13_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select CID from Customer", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Customer where CID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox2.Text = dr["CName"].ToString();
                textBox3.Text = dr["City"].ToString();
                textBox4.Text = dr["PH1"].ToString();
                textBox5.Text = dr["ContactPerson"].ToString();
                textBox6.Text = dr["CreditLimit"].ToString();
                textBox7.Text = dr["CStatus"].ToString();
                textBox1.Text = dr["CGroup"].ToString();


            }
        }
    }
}
