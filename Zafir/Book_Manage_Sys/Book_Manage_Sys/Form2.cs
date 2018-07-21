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
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            f1.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select Tittle from Books ", f1.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["Tittle"]).ToString();
               // comboBox2.Items.Add(dr1["Category"]).ToString();
            }


            f1.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            f1.sqlConnection1.Open();
            SqlDataAdapter sd = new SqlDataAdapter("Select *from Books ", f1.sqlConnection1);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            f1.sqlConnection1.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            f1.sqlConnection1.Open();
            SqlDataAdapter sd = new SqlDataAdapter("Select *from Books where Tittle = '"+comboBox1.Text+"' ", f1.sqlConnection1);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            f1.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select Category from Books where Tittle = '" + comboBox1.Text + "'", f1.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
               // comboBox1.Items.Add(dr1["Tittle"]).ToString();
                comboBox2.Items.Add(dr1["Category"]).ToString();
            }


            f1.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book_Portal bk = new Book_Portal();
            bk.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bills bl = new Bills();
            bl.Show();
        }

        private void Cust_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer cs = new Customer();
            cs.Show();
        }

        }
    }

