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
    public partial class Form11 : Form
    {
        Form1 conn = new Form1();
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            textBox7.ReadOnly = true;
            textBox7.Text = "ACTIVE";
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select CID from Customer where CStatus = 'SFA' ", conn.oleDbConnection1);
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
                textBox1.Text = dr["CGroup"].ToString();
                

            }

            conn.oleDbConnection1.Close();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Customer set Cname=@Cname,City=@City,PH1=@PH1,ContactPerson=@ContactPerson,CreditLimit=@CreditLimit,CStatus=@CStatus,CGroup=@CGroup where CID=@CID", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@ContactPerson", textBox5.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox6.Text);
            cmd.Parameters.AddWithValue("@CStatus", textBox7.Text);
            cmd.Parameters.AddWithValue("@CGroup", textBox1.Text);
            cmd.Parameters.AddWithValue("@CID", comboBox1.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show(" Sent for Approval");
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string status = "INACTIVE";
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Customer set Cname=@Cname,City=@City,PH1=@PH1,ContactPerson=@ContactPerson,CreditLimit=@CreditLimit,CStatus=@CStatus where CID=@CID", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@ContactPerson", textBox5.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox6.Text);
            cmd.Parameters.AddWithValue("@CStatus", status);
            cmd.Parameters.AddWithValue("@CID", comboBox1.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show("CUSTOMER CAN NOT BE APPROVED");
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }
    }
}
