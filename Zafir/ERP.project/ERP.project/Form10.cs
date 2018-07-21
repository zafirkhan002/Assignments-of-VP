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
    public partial class Form10 : Form
    {
        Form1 conn = new Form1();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string[] grp = { "HR", "Marketing", "Sales", "Consumer" };
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(grp);

            textBox7.ReadOnly = true;
            textBox7.Text = "SFA";
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(CID) from Customer ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox1.Text = "C-0" + c.ToString() + "-" + System.DateTime.Today.Year;
            conn.oleDbConnection1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Customer (CID,Cname,City,PH1,ContactPerson,CreditLimit,CStatus,CGroup) values(@CID,@Cname,@CAddress,@City,@ContactPerson,@CreditLimit,@CStatus,@CGroup)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@ContactPerson", textBox5.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox6.Text);
            cmd.Parameters.AddWithValue("@CStatus", textBox7.Text);
            cmd.Parameters.AddWithValue("@CGroup", comboBox1.Text);
            //CGroup
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show(" Sent for Approval");
            this.Hide();
            Form11 f11 = new Form11();
            f11.Show();

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}