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
    public partial class Customer : Form
    {
        Form1 f1 = new Form1();
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            this.panel3.Visible = false;
            this.panel1.Visible = false;
            f1.sqlConnection1.Open();
            int c = 0;

            SqlCommand cmd1 = new SqlCommand("select count(CID) from Customer", f1.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                c = Convert.ToInt32(dr1[0]);
                c++;
                // comboBox2.Items.Add(sd["DRName"]).ToString();
            }

            textBox6.Text = c.ToString();
            f1.sqlConnection1.Close();
             f1.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select CID from Customer", f1.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               
                comboBox1.Items.Add(dr["CID"]).ToString();
            }

            f1.sqlConnection1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;
            this.panel1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            f1.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Customer (CFullName,CEmail,Contact,Address,City) values(@CFullName,@CEmail,@Contact,@Address,@City)", f1.sqlConnection1);
            //CFullName  CEmail  Contact Address City
          
            cmd.Parameters.AddWithValue("@CFullName ", textBox1.Text);
            cmd.Parameters.AddWithValue("@CEmail", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Address ", textBox4.Text);
            cmd.Parameters.AddWithValue("@City", textBox5.Text);
           

            cmd.ExecuteNonQuery();
            f1.sqlConnection1.Close();
            MessageBox.Show("Customer Added !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.panel3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;
            this.panel1.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.sqlConnection1.Open();
            SqlCommand cm = new SqlCommand("Select *from Customer where CID ='" + comboBox1.Text + "' ", f1.sqlConnection1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {

                textBox12.Text = dd["CFullName"].ToString();
                textBox11.Text = dd["CEmail"].ToString();
                textBox10.Text = dd["Contact"].ToString();
                textBox9.Text = dd["Address"].ToString();
                textBox8.Text = dd["City"].ToString();
                
            }
            f1.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             try{
            f1.sqlConnection1.Open();


            SqlCommand cmd = new SqlCommand("Update Customer set CFullName=@CFullName,CEmail=@CEmail,Contact=@Contact,Address=@Address,City=@City where CID  = '" + comboBox1.Text + "'", f1.sqlConnection1);
                 //CFullName=@CFullName,CEmail=@CEmail,Contact=@Contact,Address=@Address,City=@City
          
            cmd.Parameters.AddWithValue("@CFullName", textBox12.Text);
            cmd.Parameters.AddWithValue("@CEmail",textBox11.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox10.Text);
            cmd.Parameters.AddWithValue("@Address", textBox9.Text);
            cmd.Parameters.AddWithValue("@City", textBox8.Text);
            
           
            cmd.ExecuteNonQuery();
            f1.sqlConnection1.Close();
            MessageBox.Show("Customer Information Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox12.Clear();
            this.textBox11.Clear();
            this.textBox10.Clear();
            this.textBox9.Clear();
            this.textBox8.Clear();
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
