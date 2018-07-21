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
    public partial class Bills : Form
    {
        Form1 f1 = new Form1();
        string[] bname = new string[50];
        int[] price = new int[50];
        int[] qty = new int[50];
        int counter = 0;

        public Bills()
        {
            InitializeComponent();
        }

        private void Bills_Load(object sender, EventArgs e)
        {
            f1.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select CID from Customer", f1.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                comboBox1.Items.Add(dr["CID"]).ToString();
            }

            f1.sqlConnection1.Close();

            f1.sqlConnection1.Open();
            SqlCommand cd = new SqlCommand("select Tittle from Books ", f1.sqlConnection1);
            SqlDataReader dd = cd.ExecuteReader();
            while (dd.Read())
            {
                comboBox2.Items.Add(dd["Tittle"]).ToString();

            }


            f1.sqlConnection1.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

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
               
            }
            f1.sqlConnection1.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.sqlConnection1.Open();
            SqlCommand cm = new SqlCommand("Select *from Books where Tittle ='" + comboBox2.Text + "' ", f1.sqlConnection1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {
                //Tittle,Author,Publisher,Description,ISBN,Price,Category
              //  comboBox1.Text = dd["Tittle"].ToString();
               
                textBox1.Text = dd["Price"].ToString();
               
            }
            f1.sqlConnection1.Close();
            //f1.sqlConnection1.Open();
            //SqlDataAdapter sd = new SqlDataAdapter("Select *from Books where Tittle = '" + comboBox2.Text + "' ", f1.sqlConnection1);
            //DataTable dt = new DataTable();
            //sd.Fill(dt);
            
            //dataGridView1.DataSource = dt;

            //f1.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Bqty = Convert.ToInt32(textBox3.Text);
            int unit = Convert.ToInt32(textBox1.Text);
            int tprice = Bqty * unit;
            textBox2.Text = tprice.ToString();

            textBox4.Text += "**************************" + Environment.NewLine;
            textBox4.Text += "Book Name    :" + " " + comboBox2.Text + Environment.NewLine;
            textBox4.Text += "Unit Price   :" + "  " + textBox1.Text + Environment.NewLine;
            textBox4.Text += "Quantity     :" + "  " + textBox3.Text + Environment.NewLine;
            textBox4.Text +=  "Total Price : " + textBox2.Text + Environment.NewLine;
           
            bname[counter] = comboBox2.Text;
            price[counter] = Convert.ToInt32(textBox2.Text);
            qty[counter] = Convert.ToInt32(textBox3.Text);
            counter++;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           int s = 0;
            foreach (int p in price)
            {
                s = p +s;
            }
            for (int i = 0; i < counter; i++)
            {
                f1.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("insert into Bill(BillDate,CID,Bookname,BookQty,BookPrice) values(@BillDate,@CID,@Bookname,@BookQty,@BookPrice)", f1.sqlConnection1);
                //BillDate,CID,Bookname,BookQty,BookPrice
                cmd.Parameters.AddWithValue("@BillDate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@CID", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Bookname", bname[i]);
                cmd.Parameters.AddWithValue("@BookQty", qty[i]);
                cmd.Parameters.AddWithValue("@BookPrice", s);

                cmd.ExecuteNonQuery();
                f1.sqlConnection1.Close();
                
            }

            f1.sqlConnection1.Open();
            SqlCommand cm = new SqlCommand("insert into Billproduct(CID,TotalPrice) values(@CID,@TotalPrice)", f1.sqlConnection1);
            //BillDate,CID,Bookname,BookQty,BookPrice
            cm.Parameters.AddWithValue("@CID", dateTimePicker1.Text);
            cm.Parameters.AddWithValue("@TotalPrice", comboBox1.Text);
            cm.ExecuteNonQuery();
            f1.sqlConnection1.Close();
            MessageBox.Show("Bill Created !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
