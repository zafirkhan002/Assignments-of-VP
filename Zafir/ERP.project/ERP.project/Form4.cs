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
    public partial class Form4 : Form
    {
        Form1 conn = new Form1();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select Group";
            string[] grp = { "HR", "Marketing", "Sales", "Consumer" };
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(grp);

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            textBox11.ReadOnly = true;
            textBox11.Text = "SFA";
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(VID) from Vendor ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox1.Text = "V-0" + c.ToString(); //+ "-" + System.DateTime.Today.Year; 
            conn.oleDbConnection1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
           
            OleDbCommand cmd = new OleDbCommand("insert into Vendor(VID,VName,VCity,PH1,PH2,VAddress,CPName,CPPH,VEmail,VGroup,VStatus) values(@VID,@VName,@VCity,@PH1,@PH2,@VAddress,@CPName,@CPPH,@VEmail,@VGroup,@VStatus)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox5.Text);
            cmd.Parameters.AddWithValue("@VAddress", textBox6.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox7.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox8.Text);
            cmd.Parameters.AddWithValue("@VEmail", textBox9.Text);
            cmd.Parameters.AddWithValue("@VGroup", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VStatus", textBox11.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show("Send for Approval");
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
