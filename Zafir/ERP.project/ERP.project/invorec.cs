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
    public partial class invorec : Form
    {
        Form1 conn = new Form1();
        public invorec()
        {
            InitializeComponent();
        }

        private void invorec_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.textBox8.ReadOnly = true;
            int c = 0;

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from InvoiceR ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox1.Text = "0" + c.ToString() + "-" + System.DateTime.Today.Year;
            OleDbCommand cmdd = new OleDbCommand("Select DCID from DelChalan where Status ='CLOSE' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox1.Items.Add(drr["DCID"]).ToString();
            }



            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from DelChalan where DCID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox10.Text = dr["DCDate"].ToString();
                textBox3.Text = dr["SOID"].ToString();
               textBox5.Text = dr["CName"].ToString();
                textBox4.Text = dr["CID"].ToString();


            }
           // conn.oleDbConnection1.Close();
            //conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select * from SO where CName = @CName", conn.oleDbConnection1);
            cmd1.Parameters.AddWithValue("CName", textBox5.Text);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox6.Text = dr1["TotalAmount"].ToString();
                

            }
            conn.oleDbConnection1.Close();
        }

       

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox6.Text);
            int disc = Convert.ToInt32(textBox9.Text);
            int discount = (price * disc) / 100;
            int d = price - discount;
            textBox8.Text = d.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into InvoiceR(InvoiceID,CustID,CustName,DCDate,InvoiceDate,AmountRecievable,DelCID) values(@InvoiceID,@CustID,@CustName,@DCDate,@InvoiceDate,@AmountRecievable,@DelCID)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@InvoiceID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CustID", textBox4.Text);
            cmd.Parameters.AddWithValue("@CustName", textBox5.Text);
            cmd.Parameters.AddWithValue("@DCDate", textBox10.Text);
            cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@AmountRecievable", textBox8.Text);
            cmd.Parameters.AddWithValue("@DelCID", comboBox1.Text);


            cmd.ExecuteNonQuery();

            conn.oleDbConnection1.Close();
            MessageBox.Show("Please recieve this Bill");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
