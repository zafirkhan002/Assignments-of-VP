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
    public partial class so : Form
    {

        string[] pid = new string[50];
        int[] qtty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;


        Form1 conn = new Form1();
        public so()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox11.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand cd = new OleDbCommand("Select *from Products where Pid = '" + comboBox3.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cd.ExecuteReader();

            if (dr.Read())
            {

                textBox5.Text = dr["ProductType"].ToString();
                textBox6.Text = dr["PName"].ToString();
                textBox7.Text = dr["BasePrice"].ToString();


            }

            conn.oleDbConnection1.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tprice;
            int ptprice = Convert.ToInt32(textBox7.Text);
            int qty = Convert.ToInt32(textBox8.Text);

            tprice = qty * ptprice;
           textBox11.Text = tprice.ToString();

            textBox9.Text += label8.Text + "  : " + comboBox3.Text + Environment.NewLine;
            textBox9.Text += label11.Text + " : " + textBox5.Text + Environment.NewLine;
            textBox9.Text += label13.Text + " : " + textBox6.Text + Environment.NewLine;
            textBox9.Text += label12.Text + " : " + textBox7.Text + Environment.NewLine;
            textBox9.Text += label10.Text + " : " + textBox8.Text + Environment.NewLine;
            textBox9.Text += label19.Text + " : " + textBox11.Text + Environment.NewLine;

            pid[counter] = comboBox3.Text;
            qtty[counter] = Convert.ToInt32(textBox8.Text);
            pprice[counter] = Convert.ToInt32(textBox11.Text);
            counter++;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = 0;
            conn.oleDbConnection1.Open();

            OleDbCommand cmdd = new OleDbCommand("select count(SOID) from SO where CDept= '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                a = Convert.ToInt32(drr[0]);
               a++;
            }

            textBox1.Text = comboBox1.Text + "-" + a.ToString() + "-" + System.DateTime.Today.Year;

            conn.oleDbConnection1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Customer where CID = '" + comboBox2.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox2.Text = dr["Cname"].ToString();
                textBox10.Text = dr["PH1"].ToString();
                textBox3.Text = dr["CGroup"].ToString();
                textBox4.Text = dr["CPPH"].ToString();

            }

            conn.oleDbConnection1.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int s = 0;
            foreach (int p in pprice)
            {
                s = p + s;

            }

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into SO(SOID,SODate,CDept,CName,CID,CCPPH,PRICE) values(@SOID,@SODate,@CDept,@CName,@CID,@CCPPH,@PRICE)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@SOID", textBox1.Text);
            cmd.Parameters.AddWithValue("@SODate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@CDept", textBox3.Text);
            cmd.Parameters.AddWithValue("@CName", textBox2.Text);
            cmd.Parameters.AddWithValue("@CID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@CCPPH", textBox4.Text);
            
            cmd.Parameters.AddWithValue("@PRICE", s);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < counter; i++)
            {
                OleDbCommand cmd1 = new OleDbCommand("insert into SOProducts(SOID,Pid,PQty,TPPRICE) values(@SOID,@Pid,@PQty,@TPPRICE)", conn.oleDbConnection1);

                cmd1.Parameters.AddWithValue("@SOID", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Pid", pid[i]);
                cmd1.Parameters.AddWithValue("@PQty", qtty[i]);
                cmd1.Parameters.AddWithValue("@TPPRICE", pprice[i]);
               
                cmd1.ExecuteNonQuery();
                // counter++;
            }

            conn.oleDbConnection1.Close();
            MessageBox.Show("PLEASE TAKE YOUR SALE ORDER SLIP");
        }

        private void so_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox1.ReadOnly = true;
            
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Deptname from Dept ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Deptname"]).ToString();
            }


            OleDbCommand cmdd = new OleDbCommand("Select CID from Customer where CStatus = 'ACTIVE' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox2.Items.Add(drr["CID"]).ToString();
            }


            OleDbCommand cd = new OleDbCommand("Select Pid from Products ", conn.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();
            while (dnr.Read())
            {

                comboBox3.Items.Add(dnr["Pid"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
