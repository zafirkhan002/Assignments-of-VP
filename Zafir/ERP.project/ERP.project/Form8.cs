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
    public partial class Form8 : Form
    {
        Form1 conn = new Form1();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            int c = 0;
            
           conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(GRNID) from GRN ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox4.Text = "G_0" + c.ToString()+ "-" + System.DateTime.Today.Year; 


            OleDbCommand cmd1 = new OleDbCommand("Select POID from PO where Status = 'OPEN' ", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["POID"]).ToString();
            }

            conn.oleDbConnection1.Close();
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from PO where POID ='" + comboBox1.Text + "' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["VID"].ToString();
                textBox2.Text = dr["VName"].ToString();
                textBox3.Text = dr["DDate"].ToString();

            }

            OleDbDataAdapter da = new OleDbDataAdapter("Select  *from POProducts ", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.oleDbConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into GRN(GRNID,POID,Status,VName,GRDate,DDate,VID) values(@GRNID,@POID,@Status,@VName,@GRDate,@DDate,@VID)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@GRNID", textBox4.Text);
            cmd.Parameters.AddWithValue("@POID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Status", "CLOSE");
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@GRDate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@DDate", textBox3.Text);
            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.ExecuteNonQuery();

            conn.oleDbConnection1.Close();
            MessageBox.Show("GRN OK");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
