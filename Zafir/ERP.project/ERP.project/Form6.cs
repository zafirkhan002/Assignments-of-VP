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
    public partial class Form6 : Form
    {
        Form1 conn = new Form1();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string sst = "ACTIVE";
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,PH1=@PH1,CPName=@CPName,VStatus=@VStatus where VID=@VID", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VName", textBox1.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox2.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox3.Text);
            cmd.Parameters.AddWithValue("@CPNAME", textBox4.Text);
            cmd.Parameters.AddWithValue("@VStatus",sst);
            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show("Vendor is not Approved");
            this.Hide();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
             
            this.textBox5.Text = "ACTIVE";
            this.textBox5.ReadOnly = true;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select VID from Vendor where VStatus = 'INACTIVE'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]).ToString();
            }

            conn.oleDbConnection1.Close();
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


            }

            conn.oleDbConnection1.Close();
        }
        
    }
}
