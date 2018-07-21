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
    public partial class Form9 : Form
    {
        Form1 conn = new Form1();

        public Form9()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Invoice(InvoiceID,VendorID,VendorName,GRNDate,CDate,AmountPayable,GRNID) values(@InvoiceID,@VendorID,@VendorName,@GRNDate,@CDate,@AmountPayable,@GRNID)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@InvoiceID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VendorID", textBox4.Text);
            cmd.Parameters.AddWithValue("@VendorName", textBox5.Text);
            cmd.Parameters.AddWithValue("@GRNDate", textBox10.Text);
            cmd.Parameters.AddWithValue("@CDate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@AmountPayable", textBox8.Text);
            cmd.Parameters.AddWithValue("@GRNID", comboBox1.Text);
            cmd.ExecuteNonQuery();

            conn.oleDbConnection1.Close();
            MessageBox.Show("TAKE YOUR Bill");
            
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.textBox8.ReadOnly = true;
            int c = 0;

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from Invoice ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox1.Text = "0" + c.ToString()+ "-" + System.DateTime.Today.Year; 
            OleDbCommand cmdd = new OleDbCommand("Select GRNID from GRN where Status ='Close' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox1.Items.Add(drr["GRNID"]).ToString();
            }



            conn.oleDbConnection1.Close();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox6.Text);
            int disc = Convert.ToInt32(textBox9.Text);
            int discount = (price * disc) / 100;
            int d = price - discount;
            textBox8.Text = d.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from GRN where GRNID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox10.Text = dr["GRDate"].ToString();
                textBox3.Text = dr["POID"].ToString();
                textBox4.Text = dr["VID"].ToString();
                textBox5.Text = dr["VName"].ToString();

            }
            conn.oleDbConnection1.Close();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select * from PO where VName = @VName", conn.oleDbConnection1);
            cmd1.Parameters.AddWithValue("VName", textBox5.Text);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox6.Text = dr1["TotalAmount"].ToString();
                

            }
            conn.oleDbConnection1.Close();
       
        }
    }
}
