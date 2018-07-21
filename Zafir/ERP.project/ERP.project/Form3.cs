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
    public partial class Form3 : Form
    {
        Form1 conn = new Form1();
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
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
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select VID from Vendor ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]).ToString();
                
            }

            conn.oleDbConnection1.Close();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Vendor where VID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["VName"].ToString();
                textBox2.Text = dr["VCity"].ToString();
                textBox3.Text = dr["PH1"].ToString();
                textBox4.Text = dr["PH2"].ToString();
                textBox5.Text = dr["VAddress"].ToString();
                textBox6.Text = dr["CPName"].ToString();
                textBox7.Text = dr["CPPH"].ToString();
                textBox8.Text = dr["VEmail"].ToString();
                textBox9.Text = dr["VGroup"].ToString();
                textBox10.Text = dr["VStatus"].ToString();

            }

            conn.oleDbConnection1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

      
            }
}
