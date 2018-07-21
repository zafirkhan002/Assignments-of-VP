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
    public partial class Book_Portal : Form
    {
        Form1 f1 = new Form1();

        public Book_Portal()
        {
            InitializeComponent();
        }

        private void Book_Portal_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            string[] Category = { "Computer", "Business","Art","English","Sychology" };
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Category);
            f1.sqlConnection1.Open();

            int isbn = 0;

            SqlCommand cmd1 = new SqlCommand("select count(ISBN) from Books", f1.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                isbn = Convert.ToInt32(dr1[0]);
                isbn++;
               
            }

            textBox5.Text = "787" + isbn.ToString() + "-BK";
            f1.sqlConnection1.Close();

            f1.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Tittle from Books ", f1.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Tittle"]).ToString();
               
            }


            f1.sqlConnection1.Close();
            f1.sqlConnection1.Open();
            SqlCommand cm = new SqlCommand("select Tittle from Books ", f1.sqlConnection1);
            SqlDataReader ddr = cm.ExecuteReader();
            while (ddr.Read())
            {
                comboBox3.Items.Add(ddr["Tittle"]).ToString();

            }


            f1.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // try
            //{
            f1.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Books (Tittle,Author,Publisher,Description,ISBN,Price,Category) values(@Tittle,@Author,@Publisher,@Description,@ISBN,@Price,@Category)",f1.sqlConnection1);
            //@Admit_Date,@Dicharge_Date
            cmd.Parameters.AddWithValue("@Tittle", textBox1.Text);
            cmd.Parameters.AddWithValue("@Author", textBox2.Text);
            cmd.Parameters.AddWithValue("@Publisher", textBox3.Text);
            cmd.Parameters.AddWithValue("@Description",textBox4.Text);
            cmd.Parameters.AddWithValue("@ISBN", textBox5.Text);
            cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(textBox6.Text));
            cmd.Parameters.AddWithValue("@Category", comboBox1.Text);
           
            cmd.ExecuteNonQuery();
            f1.sqlConnection1.Close();
            MessageBox.Show("New Book Added !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //this.Hide();
            //Form2 f2 = new Form2();
            //f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "";
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            //this.Hide();
            //Form2 f2 = new Form2();
            //f2.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
            f1.sqlConnection1.Open();


            SqlCommand cmd = new SqlCommand("Update Books set Author=@Author,Publisher=@Publisher,Description=@Description,ISBN=@ISBN,Price=@Price,Category=@Category where Tittle  = '" + comboBox2.Text + "'", f1.sqlConnection1);

          
            cmd.Parameters.AddWithValue("@Author", textBox11.Text);
            cmd.Parameters.AddWithValue("@Publisher",textBox10.Text);
            cmd.Parameters.AddWithValue("@Description", textBox9.Text);
            cmd.Parameters.AddWithValue("@ISBN", textBox8.Text);
            cmd.Parameters.AddWithValue("@Price", textBox7.Text);
            cmd.Parameters.AddWithValue("@Category", textBox12.Text);
           
            cmd.ExecuteNonQuery();
            f1.sqlConnection1.Close();
            MessageBox.Show("Books Information Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.sqlConnection1.Open();
            SqlCommand cm = new SqlCommand("Select *from Books where Tittle ='" + comboBox2.Text + "' ", f1.sqlConnection1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {
                //Tittle,Author,Publisher,Description,ISBN,Price,Category
                
                textBox11.Text = dd["Author"].ToString();
                textBox10.Text = dd["Publisher"].ToString();
                textBox9.Text = dd["Description"].ToString();
                textBox8.Text = dd["ISBN"].ToString();
                textBox7.Text = dd["Price"].ToString();
                textBox12.Text = dd["Category"].ToString();
                


            }
            f1.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel2.Visible = true;
            this.panel3.Visible = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.sqlConnection1.Open();
            SqlCommand cm = new SqlCommand("Select *from Books where Tittle ='" + comboBox3.Text + "' ", f1.sqlConnection1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {
                //Tittle,Author,Publisher,Description,ISBN,Price,Category
                comboBox1.Text = dd["Tittle"].ToString();
                textBox17.Text = dd["Author"].ToString();
                textBox16.Text = dd["Publisher"].ToString();
                textBox15.Text = dd["Description"].ToString();
                textBox14.Text = dd["ISBN"].ToString();
                textBox13.Text = dd["Price"].ToString();
                textBox18.Text = dd["Category"].ToString();



            }
            f1.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox11.Clear();

            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox12.Clear();
            comboBox2.Text = "";
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;

                
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
             
            f1.sqlConnection1.Open();


            SqlCommand cmd = new SqlCommand("Delete from Books  where Tittle  = '" + comboBox3.Text + "'", f1.sqlConnection1);
            cmd.ExecuteNonQuery();
            f1.sqlConnection1.Close();
            MessageBox.Show("Books Information Deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
