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
    public partial class Form7 : Form
    {
        string[] pid = new string[50];
        int[] qty = new int[50];
        int[] pprice = new int[50];

        int counter = 0;

        Form1 conn = new Form1();
        public Form7()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox9.ReadOnly = true;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Deptname from Dept ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Deptname"]).ToString();
            }


            OleDbCommand cmdd = new OleDbCommand("Select VID from Vendor where VStatus = 'ACTIVE' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox2.Items.Add(drr["VID"]).ToString();
            }


            OleDbCommand cd = new OleDbCommand("Select Pid from Products ", conn.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();
            while (dnr.Read())
            {

                comboBox3.Items.Add(dnr["Pid"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            conn.oleDbConnection1.Open();

            OleDbCommand cmd1 = new OleDbCommand("select count(POID) from PO where VDept= '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                c = Convert.ToInt32(dr1[0]);
                c++;
            }

            textBox1.Text = comboBox1.Text + "-" + c.ToString() + "-" + System.DateTime.Today.Year;
            conn.oleDbConnection1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Vendor where VID = '" + comboBox2.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // textBox1.Text = dr["VID"].ToString();
                textBox2.Text = dr["VName"].ToString();
                textBox3.Text = dr["VGroup"].ToString();
                textBox4.Text = dr["CPPH"].ToString();

            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox10.Clear();
            textBox8.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("Select *from Products where Pid = '" + comboBox3.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr2 = cmd2.ExecuteReader();

            if (dr2.Read())
            {
                textBox5.Text = dr2["ProductType"].ToString();
                textBox6.Text = dr2["PName"].ToString();
                textBox7.Text = dr2["BasePrice"].ToString();
                


            }

            conn.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int totalprice;
            int price = Convert.ToInt32(textBox7.Text);
            int pqty = Convert.ToInt32(textBox8.Text);

            totalprice = pqty * price;
            textBox10.Text = totalprice.ToString();
            textBox9.Text += label8.Text + "   " + comboBox3.Text + Environment.NewLine;
            textBox9.Text += label11.Text + "   " + textBox5.Text + Environment.NewLine;
            textBox9.Text += label13.Text + "   " + textBox6.Text + Environment.NewLine;
            textBox9.Text += label12.Text + "   " + textBox7.Text + Environment.NewLine;
            textBox9.Text += label10.Text + "   " + textBox8.Text + Environment.NewLine;
            textBox9.Text += label6.Text + "    " + textBox10.Text + Environment.NewLine;
            
            pid[counter] = comboBox3.Text;
            qty[counter] = Convert.ToInt32(textBox8.Text);
            pprice[counter] = Convert.ToInt32(textBox10.Text);
            counter++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int s = 0;
            foreach (int p in pprice)
            {
                s = p + s;

            }

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into PO(POID,PODate,DDate,Status,Approve,VDept,VName,VID,VCPPH,PPRICE) values(@POID,@PODate,@DDate,@Status,@Approve,@VDept,@VName,@VID,@VCPPH,@PPRICE)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@POID", textBox1.Text);
            cmd.Parameters.AddWithValue("@PODate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@DDate", dateTimePicker2);
            cmd.Parameters.AddWithValue("@Status", "OPEN");
            cmd.Parameters.AddWithValue("@Approve", "APPROVED");
            cmd.Parameters.AddWithValue("@VDept", textBox3.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@VCPPH", textBox4.Text);
            cmd.Parameters.AddWithValue("@PPRICE", s);

            cmd.ExecuteNonQuery();


            for (int i = 0; i < counter; i++)
            {
                
                OleDbCommand cmd1 = new OleDbCommand("insert into POProducts(POID,Pid,PQty,TPPRICE) values(@POID,@Pid,@PQty,@TPPRICE)", conn.oleDbConnection1);

                cmd1.Parameters.AddWithValue("@POID", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Pid", pid[i]);
                cmd1.Parameters.AddWithValue("@PQty", qty[i]);
                cmd1.Parameters.AddWithValue("@TPPRICE", pprice[i]);
                cmd1.ExecuteNonQuery();
                // counter++;
            }

            conn.oleDbConnection1.Close();
            MessageBox.Show("TRANSACTION DONE!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }
    }
}
